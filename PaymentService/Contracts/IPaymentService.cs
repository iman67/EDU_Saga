namespace PaymentService.Contracts
{
    public interface IPaymentService
    {
        Task<Guid> Payment(Guid orderId);
    }
}
