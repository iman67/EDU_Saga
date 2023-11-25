using ShipmentService.Contracts;


namespace ShipmentService.Services
{
    public class ShipmentService: IShipmentService
    {
        //private readonly IMessageSession _messageSession;
        public Guid OrderId { get; set; }
        public ShipmentService()
        {
           // _messageSession = messageSession;
        }
        public async Task<Guid> Shipment(Guid orderId)
        {
            //await _messageSession.Send(new Shipment() {OrderId = orderId});
            return orderId;
        }
    }
}
