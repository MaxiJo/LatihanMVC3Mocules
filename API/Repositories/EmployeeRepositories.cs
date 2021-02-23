using API.Models;
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
    public class EmployeeRepositories
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConection"].ConnectionString);
        public IEnumerable<Employee> Get()
        {
            var spName = "SP_RetrieveAllEmployee";
            var result = connection.Query<Employee>(spName, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<Employee> Get(int id)
        {
            var spName = "SP_RetrieveEmployeeById";
            parameters.Add("@Id", id);
            var result = await connection.QueryAsync<Employee>(spName, parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}