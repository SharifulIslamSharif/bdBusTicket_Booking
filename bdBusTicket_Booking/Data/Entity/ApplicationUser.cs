using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace bdBusTicket_Booking.Data.Entity
{
    public class ApplicationUser:IdentityUser
    {
        public int? userTypeId { get; set; }//1=Admin|2=counte admin|3=customer

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Citizenship { get; set; }

        public int? NationalIdentityType { get; set; }
        [StringLength(100)]
        public string NationalIdentityNo { get; set; }
        public int AddressType { get; set; }
        [MaxLength(100)]
        public string userFrom { get; set; }

        [StringLength(300)]
        public string ImagePath { get; set; }
        public string otpCode { get; set; }
        public int? isVarified { get; set; }

        public int? isActive { get; set; }
        public int? isChangePassword { get; set; }

        public DateTime? createdAt { get; set; }
        [MaxLength(120)]
        public string createdBy { get; set; }

        public DateTime? updatedAt { get; set; }
        [MaxLength(120)]
        public string updatedBy { get; set; }
    }
}
