namespace TodoOnBot.Telegram.Services.Interfaces
{
    internal interface ICommandService
    {
        Response ProcessCommand(Command command);
    }
}