using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
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

        }

        public Employee AddEmployee(AddEmployeeVM employeeVM, int id, string mailextension)
        {
            //şirket uzantısı doğru mu
            if (GetMailExtension(employeeVM.Email) == mailextension)//şirket mail uzantısı ile eklenen çalışan mail uzantısı aynı mu
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
                    Photo = "uploads\\image\\userphoto\\_usernophoto.png",
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
            if (employee != null)
            {
                if (employee.IsActive)
                {
                    return employee;
                }
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
            Employee updatedEmploye = employeeRepository.GetEmployeeById(id);
            return employeeRepository.UpdateEmployee(updatedEmploye, employee);
        }

        public int DeleteEmployee(int id)
        {
            Employee deletedEmployee = employeeRepository.GetEmployeeById(id);
            return employeeRepository.DeleteEmployee(deletedEmployee);
        }

        public List<Permission> GetPermissionListEmployees(int id)
        {
            return employeeRepository.GetPermissionList(id);
        }

        public bool AnyEmployeesPermission(AddEmployeesPermissionVM permissionVM)
        {
            return employeeRepository.GetPermissionById(permissionVM.EmployeeID, permissionVM.StartDate, permissionVM.FinishDate);
        }

        public List<EmployeePermissionVM> GetPermissionListEmployeeByID(int id)
        {
            List<Permission> permissions = employeeRepository.GetPermissionListEmployeeByID(id);
            List<EmployeePermissionVM> employeePermissionVMs = new List<EmployeePermissionVM>();
            if (permissions != null)
            {
                foreach (Permission item in permissions)
                {
                    EmployeePermissionVM permissionVM = new EmployeePermissionVM()
                    {
                        PermissionID = item.PermissionId,
                        PermissionType = item.PermissionType,
                        StartDate = item.StartDate,
                        FinishDate = item.FinishDate,
                        isAproved = item.isAproved
                    };
                    employeePermissionVMs.Add(permissionVM);
                
                }
            }

            return employeePermissionVMs;
        }

        public int AddPermissionEmployee(int id, EmployeePermissionVM permissionVM)
        {
            Employee employee = employeeRepository.GetEmployeeById(id);
            if (employee!=null)
            {
                Permission permission = new Permission()
                {
                    EmployeeId = id,
                    StartDate = permissionVM.StartDate,
                    FinishDate = permissionVM.FinishDate,
                    isAproved = null,
                    PermissionType = permissionVM.PermissionType,
                    ManagerId = employee.ManagerId
                };

                return employeeRepository.AddPermission(permission);

            }
            return 0;


        }

        public bool AnyFilePath(string filepath)
        {
            return employeeRepository.AnyFilePath(filepath);
        }

        public int AddDocumentByEmployeID(int id, string filepath, string fileName)
        {
            Document document = new Document()
            {
                EmployeeID = id,
                DocumentPath = filepath,
                DocumentName=fileName
            };
            return employeeRepository.AddDocument(document);
        }

        public List<DocumentVM> GetDocument(int id)
        {
            List<Document> documents = employeeRepository.GetDocumentByID(id);
            if (documents!=null)
            {
                List<DocumentVM> documentVMs = new List<DocumentVM>();
                foreach (Document document in documents)
                {
                    DocumentVM documentVM = new DocumentVM()
                    {
                        EmployeeID = (int)document.EmployeeID,
                        FilePath = document.DocumentPath,
                        DocumentID=document.DocumentID,
                        fileName=document.DocumentName
                        
                    };
                    documentVMs.Add(documentVM);
                }

                return documentVMs;
            }
            return null;
        }

        
    }
}
