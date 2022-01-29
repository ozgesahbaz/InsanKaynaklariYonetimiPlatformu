using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        Employee CheckLogin(string email, string password);
        List<Employee> GetListEmployeesByManagerID(int id);
        int AddEmployee(Employee newEmployee);
        bool AnyMail(string email);
        Employee GetEmployeeById(int id);
        int ChangesPassword(Employee employee, string password);
        int UpdateEmployee(Employee updateEmployee, Employee employee);
        int DeleteEmployee(Employee employee);
        List<Permission> GetPermissionList(int id);
        bool GetPermissionById(int? employeeID, DateTime startDate, DateTime finishDate);
        List<Permission> GetPermissionListEmployeeByID(int id);
        int AddPermission(Permission permission);
        bool AnyFilePath(string filepath);
        int AddDocument(Document document);
        List<Document> GetDocumentByID(int id);
        decimal GetSalarybyEmployeeId(int id);
        decimal GetPremiumrateByEmployeeId(int id);
        decimal GetNetSalaryByEmployeeId(int id);
    }
}
