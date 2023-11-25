namespace LoggingService.Model
{
    public class LogModel : ContainSagaData
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
