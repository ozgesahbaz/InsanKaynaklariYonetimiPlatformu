using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories
{

    public class EmployeeRepository
    {
        HRDataBaseContext dbContext;

        public EmployeeRepository()
        {
            dbContext = new HRDataBaseContext();
        }
        public Employee CheckLogin(string email, string password)
        {
            HRDataBaseContext dbContext = new HRDataBaseContext();
            return dbContext.Employees.SingleOrDefault(a => a.Email == email && a.Password == password);

        }
    }
}
