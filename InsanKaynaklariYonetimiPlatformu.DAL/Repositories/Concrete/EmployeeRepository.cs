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

        public int AddDocument(Document document)
        {
            dbContext.Documents.Add(document);
            return dbContext.SaveChanges();
        }

        public int AddEmployee(Employee newEmployee)
        {
            dbContext.Employees.Add(newEmployee);
            return dbContext.SaveChanges();
        }

        public int AddPermission(Permission permission)
        {
            dbContext.Permissions.Add(permission);
            return dbContext.SaveChanges();
        }

        public bool AnyFilePath(string filepath)
        {
            return dbContext.Documents.Any(a => a.DocumentPath == filepath);
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
            
            return dbContext.Employees.SingleOrDefault(a => a.Email == email && a.Password == password);

        }

        public int DeleteEmployee(Employee employee)
        {
            List<Debit> debits = dbContext.Debits.Where(a => a.EmployeeID == employee.EmployeeId).ToList();
            if (debits!=null)
            {
                foreach (Debit item in debits)
                {
                    dbContext.Debits.Remove(item);
                }
            }
            List<Permission> permissions = dbContext.Permissions.Where(a => a.EmployeeId == employee.EmployeeId).ToList();
            if (permissions != null)
            {
                foreach (Permission item in permissions)
                {
                    dbContext.Permissions.Remove(item);
                }
            }
            List<Shift> shifts = dbContext.Shifts.Where(a => a.EmployeeID == employee.EmployeeId).ToList();
            if (shifts != null)
            {
                foreach (Shift item in shifts)
                {
                    dbContext.Shifts.Remove(item);
                }
            }
            List<Expenditure> expenditures = dbContext.Expenditures.Where(a => a.EmployeeID == employee.EmployeeId).ToList();
            if (expenditures != null)
            {
                foreach (Expenditure item in expenditures)
                {
                    dbContext.Expenditures.Remove(item);
                }
            }
            dbContext.Employees.Remove(employee);
            return dbContext.SaveChanges();
        }

        public List<Document> GetDocumentByID(int id)
        {
            return dbContext.Documents.Where(a => a.EmployeeID == id).ToList();
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
            return dbContext.Permissions.Include("Employee").Where(a => a.ManagerId == id&&a.EmployeeId!=null).ToList();
        }

        public List<Permission> GetPermissionListEmployeeByID(int id)
        {
            return dbContext.Permissions.Where(a => a.EmployeeId == id).ToList();
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
