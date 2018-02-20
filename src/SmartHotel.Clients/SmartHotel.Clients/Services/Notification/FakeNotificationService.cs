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
                new Models.Notification { AccName="TouchPoint Program #1", Text = "Plan 30 \nActual 15", Type = NotificationType.BeGreen , colorHex="#68a8f0" },
                new Models.Notification { AccName="TouchPoint Program #3",Text = "Plan 15 \nActual 10", Type = NotificationType.Room ,colorHex="#d44aa9" },
                new Models.Notification { AccName="TouchPoint Program #2",Text = "Plan 29 \nActual 14", Type = NotificationType.Hotel, colorHex="#dea343" },
                new Models.Notification { AccName="TouchPoint Program #4",Text = "Plan 05 \nActual 02", Type = NotificationType.Other, colorHex="#85a746" }
            };

            return Task.FromResult(data.AsEnumerable());
        }

        public Task DeleteNotificationAsync(Models.Notification notification)
        {
            return Task.FromResult(false);
        }
    }
}