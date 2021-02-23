using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LatihanMVC3Mocules.Controllers
{
    public class LoginController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44373/API/")
        };
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(VM_AccountEmployee vM)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Login/Login", vM).Result;
            var readTask = response.Content.ReadAsStringAsync();
            readTask.Wait();
            var respondTask = readTask.Result;
            var responseTask = client.GetAsync("Employees/");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsAsync<IList<Employee>>();
                read.Wait();
                var id = read.Result.Where(a=>a.Email == vM.Email).FirstOrDefault().EmployeeId;


                return RedirectToAction("Index", "Employees", new { id });
            }
            return View();
            
        }
        
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(VM_AccountEmployee vM)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Accounts", vM).Result;
            if(response.IsSuccessStatusCode)
                return RedirectToAction("Login");
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(VM_AccountEmployee vM)
        {
            var putTask = client.PutAsJsonAsync<VM_AccountEmployee>("Accounts/" + vM.EmployeeId,vM);
            putTask.Wait();
            return RedirectToAction("Login");
        }
    }
}