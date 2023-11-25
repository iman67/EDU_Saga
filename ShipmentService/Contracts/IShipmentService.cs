namespace ShipmentService.Contracts
{
    public interface IShipmentService
    {
        Task<Guid> Shipment(Guid orderId);
    }
}
