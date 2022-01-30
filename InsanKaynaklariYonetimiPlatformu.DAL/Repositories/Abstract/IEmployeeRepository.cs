using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
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
        List<Debit> GetEmployeeDebitList(int id);       
        List<Expenditure> GetListExpenditure(int id);
        int AddExpenditure(Expenditure expenditure);
        Expenditure GetExpenditureById(int id);
        int DeletExpenditure(Expenditure expenditure);
        Debit GetRejectedDebitById(int id);
        int ChangeRejectedDebit(Debit debit);
        int ChangeAccount(Employee employee);
       
       
        int DeletedDocument(int id);
        List<ExpenditureDocument> GetExpenditureDocumentById(int id);
        int AddExpenditureDocument(ExpenditureDocument document);
    }
}
