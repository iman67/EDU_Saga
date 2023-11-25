using EDU_SAGA.Contracts;
using EDU_SAGA.Models;
using MessageService.Message;
using OrderService.Contracts;
using OrderService.Models;
using PaymentService.Contracts;
using ShipmentService.Contracts;

namespace EDU_SAGA.Services
{
    public class OrchestrationService : Saga<OrderSagaData>,
        IAmStartedByMessages<StartOrder>,
        IHandleMessages<Payment>,
        IHandleMessages<Shipment>,
 IOrchestrationService
    {

        #region Params
        private readonly ISaveOrder _saveOrder;
        private readonly IPaymentService _paymentService;
        private readonly IShipmentService _shipmentService;
        private readonly ILogService _logService;
        private readonly IMessageSession _messageSession;

        #endregion
        #region Ctors
        public OrchestrationService(ISaveOrder saveOrder, IPaymentService paymentService, IShipmentService shipmentService, ILogService logService)
        {
            _saveOrder = saveOrder;
            _paymentService = paymentService;
            _shipmentService = shipmentService;
            _logService = logService;
        }
        #endregion
        #region Methods
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<OrderSagaData> mapper)
        {
            mapper.ConfigureMapping<StartOrder>(message => message.OrderId).ToSaga(sagaData => sagaData.OrderId);
            mapper.ConfigureMapping<Payment>(message => message.OrderId).ToSaga(sagaData => sagaData.OrderId);
            mapper.ConfigureMapping<Shipment>(message => message.OrderId).ToSaga(sagaData => sagaData.OrderId);
        }
        public async Task StartOrder()
        => await _saveOrder.Save(new Order { Name = "", Id = Guid.NewGuid(), Price = 0 });

        private async Task SendLog(string message, string type, IMessageHandlerContext context)
        {
            var options = new SendOptions();
            options.SetDestination("LogEndpoint");
            options.RouteReplyTo("LogEndpoint");
            await context.Send(new Log { Message = message, Type = type }, options);
        }

        #endregion
        #region Handle
        public async Task Handle(StartOrder message, IMessageHandlerContext context)
        {
            if (message.OrderId != Guid.Empty)
            {
                Data.OrderId = message.OrderId;
                Data.SaveProcessed = true;
                //await _paymentService.Payment(message.OrderId);
                //===============================Log==
                await SendLog("SaveOrder", "Info", context);
                //====================================
                await context.SendLocal(new Payment() { OrderId = message.OrderId });
            }

        }

        public async Task Handle(Payment message, IMessageHandlerContext context)
        {
            if (message.OrderId != Guid.Empty)
            {
                Data.OrderId = message.OrderId;
                Data.PaymentProcessed = true;
                //await _shipmentService.Shipment(message.OrderId);
                await SendLog("Payment_Processed", "Info", context);
                await context.SendLocal(new Shipment { OrderId = message.OrderId });
            }
        }

        public async Task Handle(Shipment message, IMessageHandlerContext context)
        {
            if (message.OrderId != Guid.Empty)
            {
                Data.OrderId = message.OrderId;
                Data.ShipmentPrepared = true;
                await SendLog("Shipment_Processed", "Info", context);
                //await _shipmentService.Shipment(message.OrderId);
            }
        }
        #endregion



    }
}
