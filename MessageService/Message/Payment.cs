namespace MessageService.Message
{
    public class Payment : ICommand
    {
        public Guid OrderId { get; set; }
    }
}
