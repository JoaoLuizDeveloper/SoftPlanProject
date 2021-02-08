using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;

namespace SoftPlanAPI.Services
{
    /// <summary>
    /// Notification
    /// </summary>
    public class NotificationHandler : INotificationHandler<Notification>
    {
        private List<Notification> _notifications;

        public NotificationHandler()
            => _notifications = new List<Notification>();
        
        public Task Handle(Notification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public virtual List<Notification> GetNotifications() 
            => _notifications;

        public virtual bool HasNotifications 
            => GetNotifications().Any();
    }
}