using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bdBusTicket_Booking.Areas.Boocking.Models;
using bdBusTicket_Booking.Data.Entity;
using bdBusTicket_Booking.Data.Entity.Admin;
using bdBusTicket_Booking.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace bdBusTicket_Booking.Areas.Boocking.Controllers
{
    [Area("Boocking")]
    public class bdTicketController : Controller
    {
        private readonly IRepository<AdminInfo> _admin;
        private readonly IRepository<Customer> _customer;
        public bdTicketController(IRepository<AdminInfo> admin, IRepository<Customer> customer)
        {
            _admin = admin;
            _customer = customer;
        }
        [HttpGet]
        public async Task<IActionResult> CustomerInfo(int id)
        {
            var data = new CustomerViewModel
            {
                customer = _customer.Get(id)
            };
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerInfo([FromForm] CustomerViewModel model)
        {
            var customer = new Customer
            {
                Id = model.customerId,
                fname = model.fname,
                lname = model.lname,
                dob = model.dob,
                gender = model.gender,
                age = model.age,
                contact = model.contact,
                address = model.address
            };

            if (model.customerId > 0)
            {
                _customer.Update(customer);
            }
            else
            {
                _customer.Insert(customer);
            }
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var data = new CustomerViewModel
            {
                customers= _customer.GetAll()
            };
            return View(data);
        }
        //public async Task<JsonResult> DeleteCustomerInfo(int id)
        //{
        //    _customer.Delete(id);
        //    return Json();
        //}
    }
}