using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bdBusTicket_Booking.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]

    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }


    }
}