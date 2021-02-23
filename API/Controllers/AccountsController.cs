using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{

    public class AccountsController : ApiController
    {
        AccountRepositories accountRepository = new AccountRepositories();
        public IHttpActionResult Post(VM_AccountEmployee vM_AccountEmployee)
        {
            var CreateAccount = accountRepository.Create(vM_AccountEmployee);
            if (CreateAccount == 0)
                return BadRequest();
            return Ok("data has been inputted");
        }
        //public IHttpActionResult Get()
        //{
        //    var getAll = accountRepository.Get();
        //    if (getAll != null)
        //    {
        //        return Ok(getAll);
        //    }
        //    return NotFound();
        //}
        
        public IHttpActionResult Put(VM_AccountEmployee vM)
        {
            var UpdateAccount = accountRepository.Update(vM);
            if (UpdateAccount == 0)
                return BadRequest();
            return Ok();
        }
    }
}
