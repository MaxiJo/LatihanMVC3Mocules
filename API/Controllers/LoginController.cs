using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class LoginController : ApiController
    {
        AccountRepositories accountRepository = new AccountRepositories();
        // GET: Login
        public IHttpActionResult Post(VM_AccountEmployee vM)
        {
            
            var Login = accountRepository.Login(vM);
            //Login.Wait();
            
            //var temp = Login.Result.ToList();
            if (Login == 0)
            {
                return NotFound();
            }
            return Ok(Login);
        }
    }
}