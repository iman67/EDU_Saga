using OrderService.Models;

namespace OrderService.Contracts
{
    public interface ISaveOrder
    {
        Task<Guid> Save(Order  order);
    }
}
