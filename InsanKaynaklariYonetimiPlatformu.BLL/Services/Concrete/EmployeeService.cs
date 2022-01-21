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
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
            //employeeRepository = new EmployeeRepository();
        }

        public Employee AddEmployee(AddEmployeeVM employeeVM, int id, string mailextension)
        {
            //şirket uzantısı doğru mu
            if (GetMailExtension(employeeVM.Email) == mailextension)//şirket mail uzantısı ile eklenen çalışan mail uzantısı aynı mu
            {
                if (!employeeRepository.AnyMail(employeeVM.Email))
                {
                    int employeeAge = DateTime.Now.Year-employeeVM.BirtDay.Year ;
                    if (employeeAge > 18)
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
                        if (employeeRepository.AddEmployee(newEmployee) > 0)
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
                        throw new Exception("18 yaşını tamamlamamış çalışan kaydı yapılamaz.");

                    }
                }
                else
                {
                    throw new Exception("Bu kullanıcı zaten kayıtlı.");
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
            if ( employee.IsActive) // calısan aktif olmadan  giriş denemesi yaptığında hata  göstermiyor   employee null dönüyor ( object referances  gösteriyor)
            {
                return employee;
            }
            return null;
        }

        public List<Employee> GetListEmployees(int id)
        {
            List<Employee> employees = employeeRepository.GetListEmployeesByManagerID(id);
            if (employees != null)
            {
                return employees.OrderBy(a => a.FullName).ToList();
            }
            return null;
        }

        public Employee GetEmployeeById(int id)
        {
            return employeeRepository.GetEmployeeById(id);
        }

        public int ChangesPassword(Employee employee, string password)
        {
            return employeeRepository.ChangesPassword(employee, password);
        }

        public int UpdateEmployees(int id, Employee employee)
        {
            Employee updateEmployee = employeeRepository.GetEmployeeById(id);
            if (updateEmployee==null)
            {
                throw new Exception("Bir hata oluştu.");
            }
           
            return employeeRepository.UpdateEmployee(updateEmployee,employee);

                
        }

        public int DeleteEmployee(int id)
        {
            Employee employee = employeeRepository.GetEmployeeById(id);
            if (employee==null)
            {
                throw new Exception("Kullanıcı zaten silinmiş.");
            }
            return employeeRepository.DeleteEmployee(employee);
        }
    }
}
