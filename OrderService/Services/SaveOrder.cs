using MessageService.Message;
using OrderService.Contracts;
using OrderService.Models;

namespace OrderService.Services
{
    public class SaveOrder : ISaveOrder
    {
        private readonly IMessageSession _messageSession;

        public SaveOrder(IMessageSession messageSession)
        {
            _messageSession = messageSession;
        }
        public async Task<Guid> Save(Order order)
        {
            var orderId= Guid.NewGuid();
            await _messageSession.Send(new StartOrder(){OrderId = orderId});
            return orderId;
        }


    }
   
}
