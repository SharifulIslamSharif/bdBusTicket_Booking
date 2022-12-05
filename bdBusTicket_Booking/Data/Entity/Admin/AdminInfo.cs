using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdBusTicket_Booking.Data.Entity.Admin
{
    public class AdminInfo:Base
    {
        public string name { get; set; }

        public string email { get; set; }

        public string imgUrl { get; set; }

        public string mobile { get; set; }

        public int? status { get; set; }

        public String ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
