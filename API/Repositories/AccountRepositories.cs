using API.Models;
using API.Repositories.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class AccountRepositories : IAccountRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConection"].ConnectionString);
        public int Create(VM_AccountEmployee vM_AccountEmployee)
        {
            var spName = "SP_InsertEmployeeAccount";
            parameters.Add("@Nama", vM_AccountEmployee.Nama);
            parameters.Add("@posisi", vM_AccountEmployee.Posisi);
            parameters.Add("@Email", vM_AccountEmployee.Email);
            parameters.Add("@PhoneNumber", vM_AccountEmployee.PhoneNumber);
            parameters.Add("@BirthDate", vM_AccountEmployee.BirthDate);
            parameters.Add("@Password", vM_AccountEmployee.Passwords);
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
        public IEnumerable<VM_AccountEmployee> Get()
        {
            var spName = "SP_RetrieveAllEmployee";
            var result = connection.Query<VM_AccountEmployee>(spName, commandType: CommandType.StoredProcedure);
            return result;
        }

        public int Update(VM_AccountEmployee vM)
        {
            var spName = "SP_UpdateAccount";
            parameters.Add("@Email", vM.Email);
            parameters.Add("@Password", vM.Passwords);
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
        public int Login(VM_AccountEmployee vM)
        {
            var spName = "SP_Login";
            parameters.Add("@Email", vM.Email);
            parameters.Add("@Password", vM.Passwords);
            var result =connection.Query<Int32>(spName, parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}