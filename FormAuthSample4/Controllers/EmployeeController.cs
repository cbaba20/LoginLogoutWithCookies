using FormAuthSample4.Models;
using FormAuthSample4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormAuthSample4.Controllers
{
    public class EmployeeController : Controller
    {
        TestDBEntities db = new TestDBEntities();
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeViewModel empVM = new EmployeeViewModel();
            empVM.ListofEmployee = db.Employees.ToList();

            return View(empVM);
        }
    }
}