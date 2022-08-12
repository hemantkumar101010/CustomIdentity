using Asp.NetCoreIdentityCustom.Models;
using Asp.NetCoreIdentityCustom.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreIdentityCustom.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeServices _employeeServices;
        public EmployeeController(EmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [Authorize(Policy = "readonlypolicy")]
        public IActionResult Index()
        {
            var data = _employeeServices.Get();
            return View(data);
        }

      [Authorize(Policy = "writepolicy")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            var emps = _employeeServices.Create(employeeViewModel);
            return View("Index", emps);
        }
    }
}


