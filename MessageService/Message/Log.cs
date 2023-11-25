namespace MessageService.Message
{
    public class Log : ICommand
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
