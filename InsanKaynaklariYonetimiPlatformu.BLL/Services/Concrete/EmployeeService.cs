using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            List<Employee> employees = employeeRepository.GetListEmployeesByManagerID(id);
            int consistEmployee = 0;
            foreach (Employee item in employees)
            {
<<<<<<< HEAD
                ContainsSymbolorNumber(employeeVM.FullName);
                ContainsSymbolorNumber(employeeVM.Status);



                Employee newEmployee = new Employee
=======
              bool  consist =item.Email==employeeVM.Email ? false : true;
                if (!consist)
>>>>>>> aca93f99537c7e670396ef411a2c63a42d27cf0f
                {
                    consistEmployee++;
                }
            }
            if (consistEmployee==0)
            {
            //şirket uzantısı doğru mu
                if (GetMailExtension(employeeVM.Email) == mailextension)//şirket mail uzantısı ile eklenen çalışan mail uzantısı aynı mu
                {
                    Employee newEmployee = new Employee
                    {
                        FullName = employeeVM.FullName.Trim(),
                        Email = employeeVM.Email.Trim(),
                        ManagerId = id,
                        StartDate = employeeVM.StartDate,
                        BirthDay = employeeVM.BirtDay,
                        Password = $"123{employeeVM.FullName.ToLower()}".Trim(),
                        Status = employeeVM.Status,
                        Photo = "uploads\\image\\userphoto\\_usernophoto.png",
                        IsActive = false,
                       NetSalary=employeeVM.Salary
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
            else
            {
                throw   new Exception("Daha önce bu kullanıcı eklenmiş");
            }


        }

        private static void ContainsSymbolorNumber(string text)
        {
            char[] harfler = text.ToCharArray();
            foreach (char harf in harfler)
            {
                if (char.IsSymbol(harf) || char.IsNumber(harf))
                {
                    throw new Exception($"{text} bir sayı veya özel karakter içeriyor. Yeniden deneyiniz.");
                }
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
            ContainsSymbolorNumber(employee.FullName);
            ContainsSymbolorNumber(employee.Status);
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
            //Manager Personellerin izinlerini listelerken
            return employeeRepository.GetPermissionList(id);
        }

        public bool AnyEmployeesPermission(AddEmployeesPermissionVM permissionVM)
        {
            //Repository kısmında save changes yaparken sıfırdan büyük çıkarsa izin ekliyor.
            return employeeRepository.GetPermissionById(permissionVM.EmployeeID, permissionVM.StartDate, permissionVM.FinishDate);
        }

        public List<EmployeePermissionVM> GetPermissionListEmployeeByID(int id)
        {
            //Personel izinleri listelerken 
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
            if (employee != null)
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

        public List<EmployeeDebitVM> GetEmployeeDebitList(int id)
        {
            List<Debit> debits = employeeRepository.GetEmployeeDebitList(id);
            List<EmployeeDebitVM> debitVMs = new List<EmployeeDebitVM>();
            if (debits != null)
            {
                foreach (Debit debit in debits)
                {
                    EmployeeDebitVM employeeDebitVM = new EmployeeDebitVM()
                    {
                        ID = debit.ID,
                        DebitName = debit.DebitName.Trim(),
                        Details = debit.Details.Trim(),
                        StartedDate = debit.StartedDate,
                        DescofRejec = debit.DescofRejec,
                        IsAproved = debit.IsAproved

                    };
                    debitVMs.Add(employeeDebitVM);


                }

            }
            return debitVMs;
        }

        public List<ExpenditureVM> GetListExpenditure(int id)
        {
            
            List<Expenditure> expenditures = employeeRepository.GetListExpenditure(id);

            if (expenditures != null)
            {
                List<ExpenditureVM> expenditureVMs = new List<ExpenditureVM>();
                foreach (Expenditure expenditure in expenditures)
                {
                    ExpenditureVM expenditureVM = new ExpenditureVM()
                    {
                        ID = expenditure.ID,
                        ExpenditureName = expenditure.ExpenditureName.Trim(),
                        ExpenditureAmount = expenditure.ExpenditureAmount,
                        Details = expenditure.Details.Trim(),
                        isAproved = expenditure.isAproved

                    };
                    expenditureVMs.Add(expenditureVM);

                }
                return expenditureVMs;
            }
            return null;
        }

        public int AddExpenditure(int id, ExpenditureVM expenditureVM)
        {
            Employee employee = employeeRepository.GetEmployeeById(id);

            Expenditure expenditure = new Expenditure()
            {
                //ID = expenditureVM.ID,
                ExpenditureName = expenditureVM.ExpenditureName.Trim(),
                ExpenditureAmount = expenditureVM.ExpenditureAmount,
                Details = expenditureVM.Details.Trim(),
                isAproved = expenditureVM.isAproved,
                EmployeeID = id,
                ManagerID = employee.ManagerId


            };
            return employeeRepository.AddExpenditure(expenditure);

        }

        public int RemoveExpenditure(int id)
        {
            Expenditure expenditure = employeeRepository.GetExpenditureById(id);
            return employeeRepository.DeletExpenditure(expenditure);
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
                DocumentName = fileName
            };
            return employeeRepository.AddDocument(document);
        }

        public List<DocumentVM> GetDocument(int id)
        {
            List<Document> documents = employeeRepository.GetDocumentByID(id);
            if (documents != null)
            {
                List<DocumentVM> documentVMs = new List<DocumentVM>();
                foreach (Document document in documents)
                {
                    DocumentVM documentVM = new DocumentVM()
                    {
                        EmployeeID = (int)document.EmployeeID,
                        FilePath = document.DocumentPath,
                        DocumentID = document.DocumentID,
                        fileName = document.DocumentName.Trim()

                    };
                    documentVMs.Add(documentVM);
                }

                return documentVMs;
            }
            return null;
        }

        public Debit GetDebitById(int id)
        {
            return employeeRepository.GetRejectedDebitById(id);
        }

        public int ChangeRejectedDebit(int id, EmployeeDebitVM employeeDebitVM)
        {
            Debit debit = GetDebitById(id);
            debit.DescofRejec = employeeDebitVM.DescofRejec;
            debit.IsAproved = false;
            return employeeRepository.ChangeRejectedDebit(debit);
        }

        public int ChangeAccount(int id, AccountSettingVM accountSettingVM, string documentPath)
        {
            Employee employee = GetEmployeeById(id);
            if (employee != null)
            {
                employee.FullName = accountSettingVM.FullName;
                if (documentPath != null)
                {
                    employee.Photo = documentPath;
                }

                return employeeRepository.ChangeAccount(employee);
            }
            else
            {
                return 0;
            }
        }

        public int RemoveDocument(int id)
        {
            return employeeRepository.DeletedDocument(id);
        }

        public decimal GetSalarybyEmployeeId(int id)
        {
            return employeeRepository.GetSalarybyEmployeeId(id);
        }

        public decimal GetPremiumRateByEmployeeId(int id)
        {
            return employeeRepository.GetPremiumrateByEmployeeId(id);
        }

        public decimal GetNetSalaryByEmployeeId(int id)
        {
            return employeeRepository.GetNetSalaryByEmployeeId(id);
        }

        public List<DocumentsVM> GetExpenditureDocument(int id)
        {
            List<ExpenditureDocument> expenditureDocument = employeeRepository.GetExpenditureDocumentById(id);
            if (expenditureDocument != null)
            {
                List<DocumentsVM> documentsVMs = new List<DocumentsVM>();
                foreach (ExpenditureDocument expenditure in expenditureDocument)
                {
                    DocumentsVM documentsVM = new DocumentsVM()
                    {
                        DocumentID = expenditure.DocumentID,
                        ExpenditureId = (int)expenditure.ExpenditureId,
                        FilePath = expenditure.DocumentPath,
                        fileName = expenditure.DocumentName
                   

                    };
                    documentsVMs.Add(documentsVM);
                }

                return documentsVMs;

            }
            return null;
        }

        public int AddDocumentByExpenditureID(int id, string documentPath, string fileName)
        {
            ExpenditureDocument document = new ExpenditureDocument()
            {
                ExpenditureId = id,
                DocumentPath = documentPath,
                DocumentName = fileName.Trim()
            };
            return employeeRepository.AddExpenditureDocument(document);
        }

        public int ChangePassword(int id, EmployeePasswordVM employeePasswordVM)
        {
            Employee employee = employeeRepository.FindEmployee(id);
            if (employee!=null)
            {
                if (employee.Password == employeePasswordVM.OldPassword)
                {
                    if (employeePasswordVM.NewPassword==employeePasswordVM.AgainNewPassword)
                    {
                        employee.Password = employeePasswordVM.NewPassword;
                        return employeeRepository.ChangesPassword(employee);
                    }
                    else
                    {
                        throw new Exception("Girdiğiniz şifreler uyuşmamaktadır.");
                    }

                }
                else
                {
                    throw new Exception("Girilen şifre yanlıştır.Lütfen tekrar deneyiniz");
                }
            }
            else
            {
                throw new Exception("Bir hata oluştu");
            }
        }

        public Employee GetEmployeeByMail(string email)
        {
            Employee employee = employeeRepository.GetEmployeeByMail(email);
            if (employee!=null)
            {
                Guid rastgele = Guid.NewGuid();
                employee.Password = rastgele.ToString().Substring(0, 8);
                if (employeeRepository.AddPassword(employee)>0)
                {
                    Employee employee1 = employeeRepository.GetEmployeeByMail(email);
                    MailMessage msg = new MailMessage();
                    msg.Subject = "Şifre Sıfırlama talebi.";
                    msg.From = new MailAddress("redteamproject@outlook.com");
                    msg.To.Add(new MailAddress(employee.Email));
                    msg.IsBodyHtml = true;
                    msg.Body = $"<h1 style='font-size:28px;font-weight:300;line-height:150%;margin:0;text-align:center;color:black;background-color:inherit'>Merhabalar</h1>Sayın { employee.FullName} Şifreniz değiştirilmiştir.<br/> Şifreniz {employee1.Password}";

                    SmtpClient smtp = new SmtpClient("smtp.office365.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
                    NetworkCredential AccountInfo = new NetworkCredential("redteamproject@outlook.com", "123toci123");
                    smtp.UseDefaultCredentials = false; //Standart doğrulama kullanılsın mı? -> Yalnızca gönderici özellikle istiyor ise TRUE işaretlenir.
                    smtp.Credentials = AccountInfo;
                    smtp.EnableSsl = true;
                    smtp.Send(msg);

                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            return null;
        }       

        public List<Expenditure> GetExpenditureListForManager(int id)
        {
            return employeeRepository.GetExpenditureListForManager(id);
        }

        public int GetAcceptDebitBy(int id)
        {
            Debit debit = employeeRepository.GetRejectedDebitById(id);
            if (debit!=null)
            {
                debit.IsAproved = true;
                return employeeRepository.AcceptDebit(debit);
            }
            return  0;
        }
    }
    
}
    

