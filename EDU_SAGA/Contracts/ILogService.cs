namespace EDU_SAGA.Contracts
{
    public interface ILogService
    {
        Task SendLog(string message, string type);
    }
}
