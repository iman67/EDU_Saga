namespace EDU_SAGA.Models
{
    public class OrderSagaData : ContainSagaData
    {
        public Guid OrderId { get; set; }
        public bool SaveProcessed { get; set; }
        public bool PaymentProcessed { get; set; }
        public bool ShipmentPrepared { get; set; }
    }
}
