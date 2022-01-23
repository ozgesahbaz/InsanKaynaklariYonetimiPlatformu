using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using Microsoft.EntityFrameworkCore;
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

        public bool AnyMail(string email)
        {
           return dbContext.Employees.Any(a => a.Email == email);
        
        }

        public int ChangesPassword(Employee employee, string password)
        {
            employee.Password = password;
            employee.IsActive = true;
            return dbContext.SaveChanges();
        }

        public Employee CheckLogin(string email, string password)
        {
            //HRDataBaseContext dbContext = new HRDataBaseContext();
            return dbContext.Employees.SingleOrDefault(a => a.Email == email && a.Password == password);

        }

        public int DeleteEmployee(Employee employee)
        {
            dbContext.Employees.Remove(employee);
            return dbContext.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            return dbContext.Employees.Where(a => a.EmployeeId == id).SingleOrDefault();
        }

        public List<Employee> GetListEmployeesByManagerID(int id)
        {
            return dbContext.Employees.Where(a => a.ManagerId == id).ToList();
        }

        public bool GetPermissionById(int? employeeID, DateTime startDate, DateTime finishDate)
        {
           Permission permission= dbContext.Permissions.Where(a => a.EmployeeId == employeeID && a.StartDate >= startDate && a.FinishDate > finishDate&&a.isAproved==true).SingleOrDefault();
            if (permission!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Permission> GetPermissionList(int id)
        {
            return dbContext.Permissions.Include("Employee").Where(a => a.ManagerId == id).ToList();
        }

        public int UpdateEmployee(Employee updateEmployee, Employee employee)
        {
            updateEmployee.FullName = employee.FullName;
            updateEmployee.Status = employee.Status;
            updateEmployee.BirthDay = employee.BirthDay;
            updateEmployee.StartDate = employee.StartDate;
            updateEmployee.Salary = employee.Salary;
            return dbContext.SaveChanges();
        }
    }
}
