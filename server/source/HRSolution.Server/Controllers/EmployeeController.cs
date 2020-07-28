using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSolution.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRSolution.Server.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public IActionResult Index()
        {
            return View();
        }
    }
}
