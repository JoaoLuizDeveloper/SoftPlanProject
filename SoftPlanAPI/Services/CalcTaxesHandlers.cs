using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoftPlanAPI.Services;

namespace SoftPlanAPI.Services
{
    public class CalcTaxesHandlers
        : IRequestHandler<CalcTaxes, decimal>
    {
        private readonly IMediator _mediator;
        private readonly NotificationHandler _notificationHandler;

        public CalcTaxesHandlers(IMediator mediator, INotificationHandler<Notification> notificationHandler)
        {
            _mediator = mediator;
            _notificationHandler = (NotificationHandler)notificationHandler;
        }

        /// <summary>
        /// Calc Interests
        /// </summary>
        /// <param name="message"><see cref="CancellationToken"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<decimal> Handle(CalcTaxes message, CancellationToken cancellationToken)
        {
            if (message.QtdMonths < 1 || message.QtdMonths > 12)
                await _mediator.Publish(Notification.Factory.Create(message, $"Months:{message.QtdMonths} incorrect."), cancellationToken);

            if (_notificationHandler.HasNotifications) return 0;
            var potencia = (decimal)Math.Pow(1 + ((double)message.InterestTaxes), message.QtdMonths);
            var valorCheio = Convert.ToDecimal(message.InitialValue * potencia);
            var valorCalculado = Math.Round(valorCheio, 2);
            return valorCalculado;
        }
    }
}