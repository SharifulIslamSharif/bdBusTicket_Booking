using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdBusTicket_Booking.Data.Entity.Notification
{
    public class NotificationInfo:Base
    {
        public string description { get; set; }
        public string title { get; set; }
        public DateTime? date { get; set; }
        public int? status  { get; set; } //1=unseen||2=seen
        public int? orgstatus  { get; set; } //1=unseen||2=seen
        public string remarks { get; set; }

    }
}
