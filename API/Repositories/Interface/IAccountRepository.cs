using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories.Interface
{
    interface IAccountRepository
    {
        IEnumerable<VM_AccountEmployee> Get();
        int Create(VM_AccountEmployee vM_AccountEmployee);
        int Update(VM_AccountEmployee vM);
        int Login(VM_AccountEmployee vM);
    }
}