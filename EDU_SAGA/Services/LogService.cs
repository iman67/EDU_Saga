using EDU_SAGA.Contracts;
using MessageService.Message;
namespace EDU_SAGA.Services
{
    public class LogService: ILogService
    {
        private readonly IMessageSession _messageSession;

        public LogService(IMessageSession messageSession)
        {
            _messageSession = messageSession;
        }
        public async Task SendLog(string message, string type)
        {
            await _messageSession.Publish(new Log() { Message = message,Type = type});
        }
    }
}
