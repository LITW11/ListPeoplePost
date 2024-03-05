using ListPeoplePost.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListPeoplePost.Data;
using System.Dynamic;

namespace ListPeoplePost.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
            "Data Source=.\\sqlexpress;Initial Catalog=ListPeoplePost;Integrated Security=True;";

        public IActionResult Index()
        {
            var mgr = new PersonManager(_connectionString);
            var vm = new HomePageViewModel
            {
                People = mgr.GetPeople(),
            };

            if (TempData["success-message"] != null)
            {
                vm.Message = (string)TempData["success-message"];
                ViewBag.Message = (string)TempData["success-message"];
            }

            return View(vm);
        }

        public IActionResult Add()
        {
            ViewBag.Message = "This is the awesome add multiple page!";
            return View();
        }

        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            var mgr = new PersonManager(_connectionString);
            var peopleToAdd =
                people.Where(p => !String.IsNullOrEmpty(p.FirstName) 
                && !String.IsNullOrEmpty(p.LastName)).ToList();

            mgr.AddPeople(peopleToAdd);
            if (peopleToAdd.Count > 0)
            {
                TempData["success-message"] = "People added successfully!";
            }
            return Redirect("/home/index");
        }

        public IActionResult AddSingle()
        {
            ViewBag.Message = "This is the awesome add single page!";
            return View();
        }

        [HttpPost]
        public IActionResult AddSingle(Person p)
        {
            var mgr = new PersonManager(_connectionString);
            mgr.AddPerson(p);
            TempData["success-message"] = "Single person added!! :)";
            return Redirect("/home/index");
        }
    }
}
