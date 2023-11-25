using PaymentService.Contracts;


namespace PaymentService.Services
{
    public class PaymentService: IPaymentService
    {
        //private readonly IMessageSession _messageSession;
        public Guid OrderId { get; set; }
        public PaymentService()
        {
           // _messageSession = messageSession;
        }
        public async Task<Guid> Payment(Guid orderId)
        {
            //await _messageSession.Send(new Payment() {OrderId = orderId});
            return orderId;
        }
    }
}
