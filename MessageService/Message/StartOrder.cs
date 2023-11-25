namespace MessageService.Message
{
    public class StartOrder : ICommand
    {
        public Guid OrderId { get; set; }
    }
}
