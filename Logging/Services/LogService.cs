using LoggingService.Contracts;
using LoggingService.Model;
using MessageService.Message;

namespace LoggingService.Services
{
    public class LogService: IHandleMessages<Log>,
        ILogService
    {
        #region Params
        #endregion
        #region Ctors

        public LogService()
        {
            
        }
        #endregion
        #region Methods
        //protected override void ConfigureHowToFindSaga(SagaPropertyMapper<LogModel> mapper)
        //{
        //    mapper.ConfigureMapping<Log>(message => message.Message).ToSaga(sagaData => sagaData.Message);
        //    //mapper.ConfigureMapping<Log>(message => message.Type).ToSaga(sagaData => sagaData.Type);
            
        //}
        public async Task Log(string text,string type)
        {
            using (var stream=new StreamWriter(@"D:\MyTeam\SAGA\EDU_SAGA\Logging\Logs\OrdersStepLogs.txt", true))
            {
                await stream.WriteLineAsync("===================================================");
                await  stream.WriteLineAsync($"Order status is => {text} in time {DateTime.Now}");
            }

            
        }
        public async Task Handle(Log message, IMessageHandlerContext context)
        {
           await  Log(message.Message, message.Type);
           
        }
        #endregion



    }
}
