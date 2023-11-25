namespace LoggingService.Contracts
{
    public interface ILogService
    {
        Task Log(string text, string type);
    }
}
