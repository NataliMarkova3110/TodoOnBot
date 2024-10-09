using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Types;
using TodoOnBot.Common;
using TodoOnBot.Telegram.Commands;
using TodoOnBot.Telegram.Services;
using TodoOnBot.Telegram.Services.Interfaces;

namespace TodoOnBot.Telegram
{
    internal class TelegramClient : BackgroundService
    {
        private readonly ICommandService _commandService;
        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public TelegramClient(ICommandService commandService, IMapper mapper, IConfiguration configuration)
        {
            _commandService = commandService;
            _mapper = mapper;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await StartAsync();
        }

        private async Task StartAsync()
        {
            var token = GetToken();
            var bot = new TelegramBotClient(token);

            await bot.SetMyCommandsAsync([
                new() { Command = CommandNames.Add, Description = "Add new todo task" },
                new() { Command = CommandNames.View, Description = "View all active tasks" },
                new() { Command = CommandNames.Complete, Description = "Complete selected task" },
                new() { Command = CommandNames.Delete, Description = "Delete selected task" }
            ]);
            bot.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync);
        }

        private async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<Command>(update);
            var response = _commandService.ProcessCommand(command);

            await botClient.SendTextMessageAsync(GetCurrentChat(update), response.Text, replyMarkup: response.ReplyKeyboardMarkup);
        }

        private ChatId GetCurrentChat(Update update)
        {
            return update.Message?.Chat?.Id ?? update.CallbackQuery?.Message.Chat.Id;
        }

        private string GetToken()
        {
            return _configuration.GetSection(BotConfiguration.Name).GetValue<string>(BotConfiguration.Token);
        }
    }
}