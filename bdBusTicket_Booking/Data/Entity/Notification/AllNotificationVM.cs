using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdBusTicket_Booking.Areas.Notifications.Models
{
    public class AllNotificationVM
    {
        public string BusName { get; set; }
        public DateTime? BusUpdatedAt { get; set; }
        public string BusUpdatedBy { get; set; }
    }
}
