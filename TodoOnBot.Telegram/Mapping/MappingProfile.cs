using AutoMapper;
using Telegram.Bot.Types;
using TodoOnBot.Business.Models;
using TodoOnBot.Telegram.Services;

namespace TodoOnBot.Telegram.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Command, UserDto>()
                .ForMember(user => user.UserId, opt => opt.MapFrom(command => command.UserId))
                .ForMember(user => user.UserName, opt => opt.MapFrom(command => command.UserName));

            CreateMap<Update, Command>()
                .ForMember(command => command.UserId, opt => opt.MapFrom(tg => GetUserId(tg)))
                .ForMember(command => command.UserName, opt => opt.MapFrom(tg => GetUserName(tg)))
                .ForMember(command => command.Text, opt => opt.MapFrom(tg => GetTextMessage(tg)));
        }

        private string GetTextMessage(Update update)
        {
            if (update.Message != null)
            {
                return update.Message.Text;
            }

            if (update.CallbackQuery.Message != null)
            {
                return update.CallbackQuery.Data;
            }

            return string.Empty;
        }

        private long GetUserId(Update update)
        {
            if (update.Message != null)
            {
                return update.Message.From.Id;
            }

            if (update.CallbackQuery != null)
            {
                return update.CallbackQuery.From.Id;
            }

            return default;
        }

        private string GetUserName(Update update)
        {
            if (update.Message != null)
            {
                return update.Message.From.Username;
            }

            if (update.CallbackQuery != null)
            {
                return update.CallbackQuery.From.Username;
            }

            return default;
        }
    }
}