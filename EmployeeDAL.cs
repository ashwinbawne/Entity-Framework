using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Crud_using_entity_framework.Models
{
    public class EmployeeDAL : System.Data.Entity.DbContext
    {

        public System.Data.Entity.DbSet<Employee> Employees { get; set; }





    }



}

