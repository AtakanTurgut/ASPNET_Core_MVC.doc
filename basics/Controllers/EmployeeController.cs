using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers
{
    public class EmployeeController : Controller
    {
        // string
        public String Index() 
        {
            return "Hello World.";
        }

        public IActionResult Index1() 
        {
            string message = $"Hello. {DateTime.Now.ToString()}";
            return View("Index1", message);
        }

        // View
        public ViewResult Index2() 
        {
            var names = new String[] {
                "Atakan",
                "Furkan",
                "Yağmur"
            };
            return View(names);
        }

        // Content
        public IActionResult Index3() 
        {
            return Content("Employee");
        }

        public IActionResult Index4() 
        {
            var employees = new List<Employee>() 
            {
                new Employee(){ Id = 1, FirstName = "Atakan", LastName = "Turgut", Age = 21 },
                new Employee(){ Id = 2, FirstName = "Furkan", LastName = "Üvenç", Age =  29},
                new Employee(){ Id = 3, FirstName = "Yağmur", LastName = "Soydan", Age =  20}
            };
            return View("Index4", employees);
        }
    }
}