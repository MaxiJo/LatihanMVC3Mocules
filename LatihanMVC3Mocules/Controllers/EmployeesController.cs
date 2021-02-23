using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LatihanMVC3Mocules.Controllers
{
    public class EmployeesController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44373/API/")
        };
        // GET: Employee
        public ActionResult Index(int id)
        {
            Employee employee = null;
            var responseTask = client.GetAsync("Employees/" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Employee>();
                readTask.Wait();

                employee = readTask.Result;
            }
            return View(employee);
        }
    }
}