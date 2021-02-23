using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories.Interface
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        Task<IEnumerable<Employee>> Get(int id);
        int Create(Employee employee);
        int Update(Employee employee, int id);
        int Delete(int id);
    }
}