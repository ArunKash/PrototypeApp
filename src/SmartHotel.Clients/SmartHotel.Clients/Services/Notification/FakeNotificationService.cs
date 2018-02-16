using SmartHotel.Clients.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Clients.Core.Services.Notification
{
    public class FakeNotificationService : INotificationService
    {
        public Task<IEnumerable<Models.Notification>> GetNotificationsAsync(int seq, string token)
        {
            var data = new List<Models.Notification>
            {
                new Models.Notification { Text = "Plan 30 \nActual 15", Type = NotificationType.BeGreen },
                new Models.Notification { Text = "Plan 15 \nActual 10", Type = NotificationType.Room },
                new Models.Notification { Text = "Plan 29 \nActual 14", Type = NotificationType.Hotel },
                new Models.Notification { Text = "Plan 05 \nActual 02", Type = NotificationType.Other }
            };

            return Task.FromResult(data.AsEnumerable());
        }

        public Task DeleteNotificationAsync(Models.Notification notification)
        {
            return Task.FromResult(false);
        }
    }
}