using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.BLL.Services.Concrete
{
    public class EmployeeService: IEmployeeService
    {
        IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
          
        }

        public Employee AddEmployee(AddEmployeeVM employeeVM, int id, string mailextension)
        {
            //şirket uzantısı doğru mu
            if (GetMailExtension(employeeVM.Email)==mailextension)//şirket mail uzantısı ile eklenen çalışan mail uzantısı aynı mu
            {
                Employee newEmployee = new Employee
                {
                    FullName = employeeVM.FullName,
                    Email = employeeVM.Email,
                    ManagerId = id,
                    StartDate = employeeVM.StartDate,
                    BirthDay = employeeVM.BirtDay,
                    Password = $"123{employeeVM.FullName.ToLower()}",
                    Status = employeeVM.Status,
                    IsActive = false
                };
                if (employeeRepository.AddEmployee(newEmployee)>0)
                {
                    return newEmployee;
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");

                }

            }
            else
            {
                throw new Exception("Çalışan mail uzantısı şirket mail uzantısı ile aynı olmalıdır.");
            }
            

        }

        public string GetMailExtension(string email)
        {
            string mailextension;
            string[] mailPart = email.Split('@');
            string[] mailextensionPart = mailPart[1].Split('.');
            mailextension = mailextensionPart[0];
            return mailextension;
        }

        public Employee CheckLogin(LoginVM login)
        {
            Employee employee = employeeRepository.CheckLogin(login.Email, login.Password);

            if ( employee.IsActive)
            {
                return employee;
            }
            return null;
        }

        public List<Employee> GetListEmployees(int id)
        {
            List<Employee> employees = employeeRepository.GetListEmployeesByManagerID(id);
            if (employees!=null)
            { 
               return employees.OrderBy(a => a.FullName).ToList(); 
            }
            return null;
        }

        public Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public int ChangesPassword(Employee employee, string password)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployees(int id, Employee employee)
        {
            throw new NotImplementedException();
        }

        public int DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
