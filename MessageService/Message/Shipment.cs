namespace MessageService.Message
{
    public class Shipment : ICommand
    {
        public Guid OrderId { get; set; }
    }
}
