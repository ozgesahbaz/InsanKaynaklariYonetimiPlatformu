using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Concrete
{

    public class EmployeeRepository: IEmployeeRepository
    {
        HRDataBaseContext dbContext;

        public EmployeeRepository(HRDataBaseContext dataBaseContext)
        {
            dbContext = dataBaseContext;
        }

        public int AddEmployee(Employee newEmployee)
        {
            dbContext.Employees.Add(newEmployee);
            return dbContext.SaveChanges();
        }

        public Employee CheckLogin(string email, string password)
        {
            //HRDataBaseContext dbContext = new HRDataBaseContext();
            return dbContext.Employees.SingleOrDefault(a => a.Email == email && a.Password == password);

        }

        public List<Employee> GetListEmployeesByManagerID(int id)
        {
            return dbContext.Employees.Where(a => a.ManagerId == id).ToList();
        }
    }
}
