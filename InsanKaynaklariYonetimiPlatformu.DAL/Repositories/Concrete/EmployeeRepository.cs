using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Concrete
{

    public class EmployeeRepository : IEmployeeRepository
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

        public int AddExpenditure(Expenditure expenditure)
        {
            dbContext.Expenditures.Add(expenditure);
            return dbContext.SaveChanges();
        }

        public int AddExpenditureDocument(ExpenditureDocument document)
        {
            dbContext.ExpenditureDocuments.Add(document);
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

        public int ChangeAccount(Employee employee)
        {
            return dbContext.SaveChanges();
        }


        public int ChangeRejectedDebit(Debit debit)
        {
            return dbContext.SaveChanges();
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

        public int DeletedDocument(int id)
        {
            Expenditure expenditure = dbContext.Expenditures.Where(a => a.ID == id).SingleOrDefault();
            if (expenditure == null)
            {
                return 1;
            }
            dbContext.Expenditures.Remove(expenditure);
            return dbContext.SaveChanges();
        }

        public int DeleteEmployee(Employee employee)
        {
            List<Debit> debits = dbContext.Debits.Where(a => a.EmployeeID == employee.EmployeeId).ToList();
            if (debits != null)
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
                    List<Respite> respites = dbContext.Respites.Where(a => a.ShiftId == item.ShiftId).ToList();
                    if (respites != null)
                    {
                        foreach (Respite respite in respites)
                        {
                            dbContext.Respites.Remove(respite);

                        }
                    }

                    dbContext.Shifts.Remove(item);
                }
            }
            List<Expenditure> expenditures = dbContext.Expenditures.Where(a => a.EmployeeID == employee.EmployeeId).ToList();
            if (expenditures != null)
            {
                foreach (Expenditure item in expenditures)
                {
                    List<ExpenditureDocument> expenditureDocuments = dbContext.ExpenditureDocuments.Where(a => a.ExpenditureId == item.ID).ToList();
                    if (expenditureDocuments != null)
                    {
                        foreach (ExpenditureDocument expenditureDocument in expenditureDocuments)
                        {
                            dbContext.ExpenditureDocuments.Remove(expenditureDocument);

                        }
                    }

                    dbContext.Expenditures.Remove(item);
                }
            }
            List<Document> documents = dbContext.Documents.Where(a => a.EmployeeID == employee.EmployeeId).ToList();
            if (documents!=null)
            {
                foreach (Document item in documents)
                {
                    dbContext.Documents.Remove(item);
                }
            }
            dbContext.Employees.Remove(employee);
            return dbContext.SaveChanges();
        }


        public int DeletExpenditure(Expenditure expenditure)
        {
            dbContext.Expenditures.Remove(expenditure);
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

        public List<Debit> GetEmployeeDebitList(int id)
        {
            return dbContext.Debits.Where(a => a.EmployeeID == id).ToList();
        }

        public Expenditure GetExpenditureById(int id)
        {
            return dbContext.Expenditures.Where(a => a.ID == id).SingleOrDefault();
        }

        public List<ExpenditureDocument> GetExpenditureDocumentById(int id)
        {
            return dbContext.ExpenditureDocuments.Where(a => a.ExpenditureId == id).ToList();
        }

        public List<Employee> GetListEmployeesByManagerID(int id)
        {
            return dbContext.Employees.Where(a => a.ManagerId == id).ToList();
        }

        public decimal GetNetSalaryByEmployeeId(int id)
        {
            return (decimal)dbContext.Employees.Find(id).NetSalary;
        }

        public List<Expenditure> GetListExpenditure(int id)
        {
            return dbContext.Expenditures.Where(a =>/* a.ID == id &&*/ a.EmployeeID == id).ToList();
        }

        public bool GetPermissionById(int? employeeID, DateTime startDate, DateTime finishDate)
        {
            Permission permission = dbContext.Permissions.Where(a => a.EmployeeId == employeeID && a.StartDate >= startDate && a.FinishDate > finishDate && a.isAproved == true).SingleOrDefault();
            if (permission != null)
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
            return dbContext.Permissions.Include("Employee").Where(a => a.ManagerId == id && a.EmployeeId != null).ToList();
        }

        public List<Permission> GetPermissionListEmployeeByID(int id)
        {
            return dbContext.Permissions.Where(a => a.EmployeeId == id).ToList();
        }

        public decimal GetPremiumrateByEmployeeId(int id)
        {
            return (decimal)dbContext.Employees.Find(id).PremiumRate;
        }

        public decimal GetSalarybyEmployeeId(int id)
        {

            return (decimal)dbContext.Employees.Find(id).Salary;

        }

        public Debit GetRejectedDebitById(int id)
        {
            return dbContext.Debits.Where(a => a.ID == id).SingleOrDefault();
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

        public bool UpdateEmployee4Salary(Employee employee)
        {
            Employee employeeatDb = dbContext.Employees.Find(employee.EmployeeId);
            employeeatDb = employee;
            dbContext.Employees.Update(employeeatDb);
            return dbContext.SaveChanges() > 0 ? true : false;

        }

        public Employee FindEmployee(int id)
        {
            Employee employee = dbContext.Employees.Where(a => a.EmployeeId == id).SingleOrDefault();
            return employee;
        }

        public int ChangesPassword(Employee employee)
        {
            return dbContext.SaveChanges();
        }

        public Employee GetEmployeeByMail(string email)
        {
            return dbContext.Employees.Where(a => a.Email == email).SingleOrDefault();
        }

        public int AddPassword(Employee employee)
        {
            return dbContext.SaveChanges();
        }

        public List<Expenditure> GetExpenditureListForManager(int id)
        {
            return dbContext.Expenditures.Include("Employee").Where(a => a.ManagerID == id && a.EmployeeID != null).ToList();
        }

        public int AcceptDebit(Debit debit)
        {
            return dbContext.SaveChanges();
        }

        public int AmountEmployee()
        {
            return dbContext.Employees.Count();
        }

        public List<Expenditure> GetListExpenditureByManagerID(int id)
        {
            List<Employee> employees = dbContext.Employees.Where(a => a.ManagerId == id).ToList();

            ////List<Expenditure> expenditures1 = dbContext.Expenditures.Where(a=>a.ManagerID==id).ToList();
            List<Expenditure> expenditures = new List<Expenditure>();
            foreach (Employee item in employees)
            {
                List<Expenditure> _expenditures = dbContext.Expenditures.Where(a => a.EmployeeID == item.EmployeeId).ToList();
                foreach (Expenditure expenditure in _expenditures)
                {
                    expenditures.Add(expenditure);
                }
             }
            return expenditures;
        }
    }
}
