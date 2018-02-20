using System;

namespace SmartHotel.Clients.Core.Models
{
    public class Notification
    {
        public int Seq { get; set; }

        public string AccName { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }

        public string colorHex { get; set; }

        public string imageURL { get; set; }

        public NotificationType Type { get; set; }
    }
}