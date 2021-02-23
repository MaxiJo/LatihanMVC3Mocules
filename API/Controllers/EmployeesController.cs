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
    public class EmployeesController : ApiController
    {
        EmployeeRepositories employeeRepository = new EmployeeRepositories();
        public IHttpActionResult Get()
        {
            var getAll = employeeRepository.Get();
            if (getAll != null)
            {
                return Ok(getAll);
            }
            return NotFound();
        }
        public async Task<IHttpActionResult> Get(int id)
        {
            var getById =await employeeRepository.Get(id);
            if (getById != null)
            {
                return Ok(getById);
            }
            return NotFound();
        }
    }
}
