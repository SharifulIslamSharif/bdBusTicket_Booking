using bdBusTicket_Booking.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdBusTicket_Booking.Areas.Boocking.Models
{
    public class CustomerViewModel
    {
        public int customerId { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public DateTime? dob { get; set; }
        public int? gender { get; set; } //1=male||2=female
        public int? age { get; set; }
        public string address { get; set; }
        public string contact { get; set; }

        public IEnumerable<Customer> customers { get; set; }
        public Customer customer { get; set; }
    }
}
