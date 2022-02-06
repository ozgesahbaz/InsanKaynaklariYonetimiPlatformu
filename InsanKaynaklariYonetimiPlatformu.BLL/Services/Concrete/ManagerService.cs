using InsanKaynaklariYonetimiPlatformu.DAL.Repositories;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsanKaynaklariYonetimiPlatformu.ViewModels;
using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using System.Net.Mail;
using System.Net;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;

namespace InsanKaynaklariYonetimiPlatformu.BLL.Services.Concrete
{
    public class ManagerService : IManagerService
    {
        IManagerRepository managerRepository;
        IEmployeeRepository employeeRepository;
        public ManagerService(IManagerRepository _managerRepository,IEmployeeRepository _employeeRepository)
        {
            managerRepository = _managerRepository;
            employeeRepository = _employeeRepository;

        }     

        public Company AddCompany(string companyName, string managerMail, MembershipType membership, string address)
        {
            string mailextension = GetMailExtension(managerMail);
            if (managerRepository.AnyMailExtension(mailextension))
            {
                throw new Exception("Bu şirket zaten kayıtlı.");
            }
            Company company = new Company()
            {
                CompanyName = companyName.Trim(),
                MailExtension = mailextension,
                RegisterDate = DateTime.Now,
                CompanyLogo = "uploads\\image\\company\\_companynologo.png",
                Address = address.Trim()
            };
            if (managerRepository.InsertCompany(company) > 0)
            {
                Membership membershipp = new Membership
                {
                    MembershipType = membership,
                    CompanyId = company.CompanyId
                };
                if (managerRepository.InsertMemberShip(membershipp) > 0)
                {
                    return company;
                }
            }
            throw new Exception("Bir hata oluştu.");
        }

        public Manager CheckLogin(LoginVM Login)
        {
            Manager manager = managerRepository.CheckLogin(Login.Email, Login.Password);
            if (manager != null)
            {
                if (manager.IsApproved && manager.IsActive)
                {
                    return manager;
                }
            }
            return null;
        }

        public Manager AddManager(ManagerRegisterVM register, Company company)
        {
            string mailextension = GetMailExtension(register.ManagerMail);
            if (managerRepository.AnyMail(register.ManagerMail))
            {
                throw new Exception("Bu kullanıcı zaten kayıtlı.");
            }
            if (mailextension != company.MailExtension)
            {
                throw new Exception("Bağlı olduğunuz şirketin mail uzantısına ait mail ile kayıt yapabilirsiniz");
            }
            Manager manager = new Manager()
            {
                FullName = register.ManagerFullName.Trim(),
                CompanyId = company.CompanyId,
                //StatusType = StatusType.CompanyManager, // statustype propertisi kaldırıldı admin db olusturuldugundan 
                Password = register.ManagerPassword.Trim(),
                Email = register.ManagerMail.Trim(),
                IsActive = false,
                IsApproved = false,
                Photo = "uploads\\image\\userphoto\\_usernophoto.png"
            };
            if (managerRepository.InsertManager(manager) > 0)
            {
                return manager;
            }
            else
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        public string GetMailExtension(string managerMail)
        {
            string mailextension;
            string[] mailPart = managerMail.Split('@');
            string[] mailextensionPart = mailPart[1].Split('.');
            mailextension = mailextensionPart[0];
            return mailextension;
        }

        public bool ManagerApproval(int id)
        {
            return managerRepository.managerApproval(id); //
        }

        public Company FindCompany(int companyId)
        {
            return managerRepository.FindComapny(companyId);
        }

        public Manager FindManager(int managerId)
        {
            return managerRepository.FindManager(managerId);
        }

        public Company FindCompanyByManagerID(int id)
        {
            return managerRepository.FindCompany(id);
        }

        public List<DebitVM> GetListDebit(int id)
        {
            List<Debit> debits = managerRepository.GetListDebit(id);
            List<DebitVM> debitVMs = new List<DebitVM>();
            foreach (Debit debit in debits)
            {
                DebitVM debitVM = new DebitVM()
                {
                    ID = debit.ID,
                    EmployeeName = debit.Employee.FullName.Trim(),
                    DebitName = debit.DebitName.Trim(),
                    StartedDate = debit.StartedDate,
                    Details = debit.Details.Trim(),
                    IsAproved = debit.IsAproved,
                    DescofRejec = debit.DescofRejec

                };
                debitVMs.Add(debitVM);


            }
            return debitVMs;
        }

        public int AddPermissionEmployee(AddEmployeesPermissionVM permissionVM, int id)
        {
            //izin eklemeden önce girilen tarih değerleri kontrol edilir.
            if (permissionVM.StartDate > permissionVM.FinishDate)
            {
                throw new Exception("Bitiş tarihi başlangıç tarihinden daha ileri bir tarih olmalıdır.");
            }
            else
            {
                //Hata yok ise girilen inputlar db tarafına gönderilir.
                Permission permission = new Permission()
                {
                    EmployeeId = permissionVM.EmployeeID,
                    ManagerId = id,
                    StartDate = permissionVM.StartDate,
                    FinishDate = permissionVM.FinishDate,
                    isAproved = true,
                    PermissionType = permissionVM.PermissionType
                };
                return managerRepository.AddEmployeePermission(permission);
            }

        }

        public PermissionVM GetPermissionById(int id)
        {
            Permission permission = managerRepository.GetPermissionById(id);
            if (permission != null)
            {
                PermissionVM permissionVM = new PermissionVM()
                {
                    ID = permission.PermissionId,
                    FullName = permission.Employee.FullName.Trim(),
                    StartDate = permission.StartDate,
                    FinishDate = permission.FinishDate,
                    Statu = permission.Employee.Status.Trim(),
                    IsAproved = permission.isAproved,
                    PermissionType = permission.PermissionType
                };
                return permissionVM;
            }


            return null;
        }

        public int UpdatePermission(PermissionVM permissionVM)
        {
            Permission permission = managerRepository.GetPermissionById(permissionVM.ID);
            permission.isAproved = permissionVM.IsAproved;
            permission.StartDate = permissionVM.StartDate;
            permission.FinishDate = permissionVM.FinishDate;
            permission.PermissionType = permission.PermissionType;
            return managerRepository.UpdatePermission(permission);
        }

        public int RemovePermission(int id)
        {
            Permission permission = managerRepository.GetPermissionById(id);
            return managerRepository.DeletedPermission(permission);
        }

        public List<ShiftDetailsVM> GetShiftDetail(int managerID)
        {

            List<ShiftDetailsVM> shiftDetailsVms = new List<ShiftDetailsVM>();
            ShiftDetailsVM shiftDetailsVm = new ShiftDetailsVM();
            shiftDetailsVm.Employees = managerRepository.GetEmployeesByManagerId(managerID);

            foreach (Employee employee in shiftDetailsVm.Employees)
            {

                shiftDetailsVm.EmployeeID = employee.EmployeeId;
                shiftDetailsVm.EmployeeFullName = employee.FullName.Trim();

                List<Shift> Shifts = managerRepository.GetShiftbyEmployeeId(employee.EmployeeId);
                foreach (Shift item in Shifts)
                {


                    shiftDetailsVm.ShiftFinishTime = item.ShiftFinishTime;
                    shiftDetailsVm.ShiftStartTime = item.ShiftStartTime;
                    List<Respite> respites = managerRepository.GetRespitebyShiftId(item.ShiftId);
                    foreach (Respite respite in respites)
                    {
                        shiftDetailsVm.RespiteFinishTime = respite.RespiteFinishTime;
                        shiftDetailsVm.RespiteStartTime = respite.RespiteStartTime;
                    }

                }

                shiftDetailsVms.Add(shiftDetailsVm);
            }

            return shiftDetailsVms;

        }

        public bool AddShiftDetails(ShiftDetailsVM ShiftDetailsVM, int managerID)
        {
            Shift shift = new Shift();
            Respite respite = new Respite();



            shift.EmployeeID = ShiftDetailsVM.EmployeeID;
            shift.ShiftFinishTime = ShiftDetailsVM.ShiftFinishTime;
            shift.ShiftStartTime = ShiftDetailsVM.ShiftStartTime;


            if (managerRepository.addShiftDetails(shift))
            {
                int LastofAddedShiiftID = managerRepository.GetShiftOrderyBydescending();
                respite.ShiftId = LastofAddedShiiftID;


                respite.RespiteFinishTime = ShiftDetailsVM.RespiteFinishTime;
                respite.RespiteStartTime = ShiftDetailsVM.RespiteStartTime;

              bool isadded= managerRepository.addRespitebyShiftID(respite)? true: false;
                return isadded;


            }

            else
            {
                throw new Exception(" ekleme yapılamadı.");

            }



        }

        public int AddEmployeesDebit(int id, AddEmployeesDebitVM debitVM)
        { //AddEmployeesDebitVm referans alarak Debite çeviriyoruz. Db debit atabiliriz. Bu sebeple AddEmployee debite çevrilmeli


            Debit debit = new Debit()
            {
                ManagerID = id,
                EmployeeID = debitVM.EmployeeID,
                DebitName = debitVM.DebitName.Trim(),
                StartedDate = debitVM.StartedDate,
                Details = debitVM.Details.Trim(),


            };
            //Sayfanın gitmesi gereken yer

            return managerRepository.AddEmployeeDebit(debit);
        }
        public List<ManagersPermissionVM> GetPermissionListManagers(int id)
        {
            List<Permission> permissions = managerRepository.GetPermissionByManagerId(id);
            if (permissions != null)
            {
                List<ManagersPermissionVM> permissionVMs = new List<ManagersPermissionVM>();
                foreach (Permission permission in permissions)
                {
                    ManagersPermissionVM permissionVM = new ManagersPermissionVM()
                    {
                        StartDate = permission.StartDate,
                        FinishDate = permission.FinishDate,
                        PermissionType = permission.PermissionType,
                        IsAproved = true,
                        ID = permission.PermissionId
                    };
                    permissionVMs.Add(permissionVM);
                }
                return permissionVMs;
            }


            return null;
        }

        public int AddManagersPermission(int id, ManagersPermissionVM permissionVM)
        {
            Permission permission = new Permission()
            {
                StartDate = permissionVM.StartDate,
                PermissionType = permissionVM.PermissionType,
                FinishDate = permissionVM.FinishDate,
                ManagerId = id,
                EmployeeId = null,
                isAproved = true,
            };
            return managerRepository.AddPermissionManager(permission);
        }

        public ManagersPermissionVM UpdatePermissionManager(int id)
        {
            Permission permission = managerRepository.GetPermissionById(id);
            ManagersPermissionVM permissionVM = new ManagersPermissionVM()
            {
                ID = permission.PermissionId,
                StartDate = permission.StartDate,
                FinishDate = permission.FinishDate,
                PermissionType = permission.PermissionType
            };

            return permissionVM;
        }

        public int UpdatePermissionManager(int id, ManagersPermissionVM permissionVM)
        {
            Permission permission = managerRepository.GetPermissionById(id);
            permission.PermissionType = permissionVM.PermissionType;
            permission.StartDate = permissionVM.StartDate;
            permission.FinishDate = permissionVM.FinishDate;

            return managerRepository.UpdatePermissionManager(permission);
        }

        public int RemoveDebit(int id)
        {
            Debit debit = managerRepository.GetDebitById(id);
            return managerRepository.DeletedDebit(debit);
        }


        //public int AddEmployeesDebit(int id, AddEmployeesDebitVM debitVM)
        //{ //AddEmployeesDebitVm referans alarak Debite çeviriyoruz. Db debit atabiliriz. Bu sebeple AddEmployee debite çevrilmeli
        //    Debit debit = new Debit()
        //    {
        //        ManagerID = id,
        //        EmployeeID = debitVM.EmployeeID,
        //        DebitName = debitVM.DebitName,
        //        StartedDate = debitVM.StartedDate,
        //        Details = debitVM.Details
        //    };
        //    return 1;

        //}


        public List<Shift> GetShiftDetailbyEmployeeId(int employeeId)
        {
            return managerRepository.GetShiftbyEmployeeId(employeeId);
        }

        public List<Respite> GetRespitebyShiftId(int shiftId)
        {
            return managerRepository.GetRespitebyShiftId(shiftId);
        }
        public bool DeleteShiftDetails(int shiftId)
        {
            return managerRepository.DeleteShiftDetails(shiftId) ? true : false;
        }

        public bool EditShiftDetails(ShiftDetailsVM shiftDetailsVM, int id)
        {

            Shift shift = managerRepository.GetShiftbyRespiteid(id);

            shift.ShiftFinishTime = shiftDetailsVM.ShiftFinishTime;
            shift.ShiftStartTime = shiftDetailsVM.ShiftStartTime;
            Respite respite = managerRepository.GetRespitebyRespiteID(id);
            respite.RespiteFinishTime = shiftDetailsVM.RespiteFinishTime;
            respite.RespiteStartTime = shiftDetailsVM.RespiteStartTime;
            return managerRepository.UpdateShiftDetails(shift, respite) ? true : false;



        }
        public List<ManagersDebitVM> GetListManagersDebit(int id)
        {
            //Db tarafından Debit verilerini almak için istek gönderiyoruz.
            List<Debit> debits = managerRepository.GetListManagersDebit(id);
            //Fakat biz bu bilgileri belirlediğimiz kısıtlarla listelemek istediğimiz için debit ManagerDebitVM şekline dönüştürüp listeliyoruz.
            List<ManagersDebitVM> debitVMs = new List<ManagersDebitVM>();
            foreach (Debit debit in debits)
            {
                ManagersDebitVM managersDebitVM = new ManagersDebitVM()
                {
                    ID = debit.ID,
                    DebitName = debit.DebitName.Trim(),
                    StartedDate = debit.StartedDate,
                    Details = debit.Details.Trim(),
                };
                debitVMs.Add(managersDebitVM);

            }
            return debitVMs;

        }

        public int AddManagersPersonelDebit(int id, ManagersDebitVM managersDebitVM)
        {
            Debit debit = new Debit()
            {
                DebitName = managersDebitVM.DebitName.Trim(),
                StartedDate = managersDebitVM.StartedDate,
                Details = managersDebitVM.Details.Trim(),
                IsAproved = true,
                ManagerID = id,

            };
            return managerRepository.AddDebitManager(debit);
        }

        public int RemoveDocument(int id)
        {
            return managerRepository.DeletedDocument(id);
        }
        public int ChangePassword(int id, PasswordVM passwordVM)
        {
            Manager manager = managerRepository.FindManager(id);
            if (manager != null)
            {
                if (manager.Password == passwordVM.OldPassword)
                {
                    if (passwordVM.NewPassword == passwordVM.AgainNewPassword)
                    {
                        manager.Password = passwordVM.NewPassword;
                        return managerRepository.ChangePassword(manager);

                    }
                    else
                    {
                        throw new Exception("Şifreleriniz uyuşmuyor");
                    }
                }
                else
                {
                    throw new Exception("Güncel şifrenizi doğru girmediniz.Tekrar deneyin.");
                }

            }
            else
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        public int ChangeAccount(int id, AccountSettingsVM settingsVM, string documentPath)
        {
            Manager manager = FindManager(id);
            if (manager != null)
            {
                manager.FullName = settingsVM.FullName.Trim();
                if (documentPath != null)
                {
                    manager.Photo = documentPath;
                }

                return managerRepository.ChangeAccount(manager);
            }
            else
            {
                return 0;
            }
        }

        public int ChangeCompanySettings(int id, CompanySettingsVM settingsVM, string documentPath)
        {
            Company company = FindCompanyByManagerID(id);
            if (company != null)
            {
                company.CompanyName = settingsVM.CompanyName.Trim();
                company.Address = settingsVM.Adress.Trim();
                if (documentPath != null)
                {
                    company.CompanyLogo = documentPath;
                }

                return managerRepository.ChangeSettings(company);
            }
            else
            {
                return 0;
            }
        }

        public ShiftDetailsVM GetShiftDetailbyRespiteID(ShiftDetailsVM shiftDetailsVM, int id)
        {
            shiftDetailsVM.RespiteID = id;
            Respite respite = managerRepository.GetRespitebyRespiteID(id);
            shiftDetailsVM.RespiteStartTime = respite.RespiteStartTime;
            shiftDetailsVM.RespiteFinishTime = respite.RespiteFinishTime;
            Shift shift = managerRepository.GetShiftbyRespiteid(id);
            shiftDetailsVM.ShiftFinishTime = shift.ShiftFinishTime;
            shiftDetailsVM.ShiftStartTime = shift.ShiftStartTime;
            shiftDetailsVM.ShiftID = shift.ShiftId;



            return shiftDetailsVM;
        }

        public Manager GetCommentByManagerId(int id)
        {
            Manager manager = managerRepository.GetCommentByManagerId(id);
            if (manager!=null)
            {
                return manager;
            }
            return null;
        }

        public bool AddComment(CommentVM commentVM, int id)
        {
            Manager manager = managerRepository.FindManager(id);
            Comment comment = new Comment()
            {
                ManagerId = id,
                Description = commentVM.Comment.Trim(),
                Manager = manager
            };

            return managerRepository.AddComment(comment);
        }

        public int RemoveComment(int id)
        {
            Comment comment = managerRepository.FindComment(id);
            if (comment != null)
            {
                return managerRepository.RemoveComment(comment);

            }
            return 1;
        }

        public bool UpdatePremium(EditPremiumVm editPremiumVm, int id)
        {
            Employee employee= employeeRepository.GetEmployeeById(id);
             employee.Salary = editPremiumVm.Salary;
            employee.PremiumRate=editPremiumVm.PremiumRate;
            employee.NetSalary = editPremiumVm.NetSalary;
            if (employeeRepository.UpdateEmployee4Salary(employee))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<ManagerExpenditureVM> GetListManagerExpenditure(int id)
        {
            List<Expenditure> expenditures = managerRepository.GetManagerExpenditureList(id);
            if (expenditures!=null)
            {
                List<ManagerExpenditureVM> managerExpenditureVMs = new List<ManagerExpenditureVM>();
                foreach (Expenditure expenditure in expenditures)
                {
                    ManagerExpenditureVM managerExpenditureVM = new ManagerExpenditureVM()
                    {
                        ID = expenditure.ID,
                        ExpenditureName = expenditure.ExpenditureName,
                        ExpenditureAmount = expenditure.ExpenditureAmount,
                        Details = expenditure.Details
                    };
                    managerExpenditureVMs.Add(managerExpenditureVM);
                }
                return managerExpenditureVMs;

            }
            return null;
        }

        public int AddManagerExpenditure(int id, ManagerExpenditureVM managerExpenditureVM)
        {
            Manager manager = managerRepository.GetManagerById(id);
            Expenditure expenditure = new Expenditure()
            {
                ExpenditureName = managerExpenditureVM.ExpenditureName,
                Details = managerExpenditureVM.Details,
                ExpenditureAmount = managerExpenditureVM.ExpenditureAmount,
                ManagerID = id

            };
            return managerRepository.AddManagerExpenditure(expenditure);
        }

        public int RemoveExpenditure(int id)
        {
            Expenditure expenditure = managerRepository.GetExpenditureById(id);
            return managerRepository.DeletedExpenditure(expenditure);

        }

        public List<ManagerExpenditureDocumentVM> GetExpenditureDocument(int id)
        {
            List<ExpenditureDocument> expenditureDocuments = managerRepository.GetExpenditureDocumentById(id);
            if (expenditureDocuments!=null)
            {
                List<ManagerExpenditureDocumentVM> managerExpenditureDocumentVMs = new List<ManagerExpenditureDocumentVM>();
                foreach (ExpenditureDocument expenditure in expenditureDocuments)
                {
                    ManagerExpenditureDocumentVM managerExpenditureDocumentVM = new ManagerExpenditureDocumentVM()
                    {
                        DocumentID = expenditure.DocumentID,
                        ExpenditureId = (int)expenditure.ExpenditureId,
                        FilePath = expenditure.DocumentPath,
                        fileName = expenditure.DocumentName

                    };
                    managerExpenditureDocumentVMs.Add(managerExpenditureDocumentVM);
                }

                return managerExpenditureDocumentVMs;
            }
            return null;
        }

        public int AddDocumentByExpenditureID(int id, string documentPath, string fileName)
        {
            ExpenditureDocument document = new ExpenditureDocument()
            {
                ExpenditureId = id,
                DocumentPath = documentPath,
                DocumentName = fileName
            };
            return managerRepository.AddExpenditureDocument(document);
        }

        public bool AnyFilePath(string filepath)
        {
            return managerRepository.AnyFilePath(filepath);
        }

        public Manager GetManagerByMail(string email)
        {
            Manager manager = managerRepository.GetManagerByMail(email);
            if (manager!=null)
            {
                Guid rastgele = Guid.NewGuid();
                manager.Password = rastgele.ToString().Substring(0, 8);
                if (managerRepository.AddPassword(manager)>0)
                {
                    Manager manager1 = managerRepository.GetManagerByMail(email);
                    MailMessage msg = new MailMessage();
                    msg.Subject = "Şifre Sıfırlama talebi.";
                    msg.From = new MailAddress("redteamproject@outlook.com");
                    msg.To.Add(new MailAddress(manager.Email));
                    msg.IsBodyHtml = true;
                    msg.Body = $"<h1 style='font-size:28px;font-weight:300;line-height:150%;margin:0;text-align:center;color:black;background-color:inherit'>Merhabalar</h1>Sayın { manager.FullName} Şifreniz değiştirilmiştir.<br/> Şifreniz:{manager1.Password}";

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
        public EmployeesExpenditureVM GetExpenditureByID(int id)
        {
            Expenditure expenditure = managerRepository.GetEmployeeExpenditureById(id);
            if (expenditure != null)
            {
                EmployeesExpenditureVM employeesExpenditureVM = new EmployeesExpenditureVM()
                {
                    ID = expenditure.ID,
                    //ExpenditureName = expenditure.ExpenditureName,
                    //ExpenditureAmount = expenditure.ExpenditureAmount,
                    //Details = expenditure.Details,
                    isAproved = expenditure.isAproved

                };
                return employeesExpenditureVM;
            }
            return null;
        }

        public int UpdateExpenditure(EmployeesExpenditureVM employeesExpenditureVM)
        {
            Expenditure expenditure = managerRepository.GetEmployeeExpenditureById(employeesExpenditureVM.ID);
            //expenditure.ExpenditureName = employeesExpenditureVM.ExpenditureName;
            //expenditure.ExpenditureAmount = employeesExpenditureVM.ExpenditureAmount;
            //expenditure.Details = employeesExpenditureVM.Details;
            expenditure.isAproved = employeesExpenditureVM.isAproved;
                        
            return managerRepository.UpdatedExpenditure(expenditure);
        }

        public int RemoveEmployeeExpenditure(int id)
        {
            Expenditure expenditure = managerRepository.GetExpenditureById(id);
            return managerRepository.DeletedEmployeeExpenditure(expenditure);
        }

        public List<EmployeesExpenditureVM> GetEmployeeExpenditureList(int id)
        {
            List<Expenditure> expenditures = managerRepository.GetEmployeeExpenditureList(id);
            List<EmployeesExpenditureVM> employeesExpenditureVMs = new List<EmployeesExpenditureVM>();
            if (expenditures!=null)
            {
                foreach (Expenditure expenditure in expenditures)
                {
                    EmployeesExpenditureVM employeesExpenditureVM = new EmployeesExpenditureVM()
                    {
                        ID = expenditure.ID,
                        ExpenditureName = expenditure.ExpenditureName,
                        ExpenditureAmount = expenditure.ExpenditureAmount,
                        Details = expenditure.Details,
                        isAproved = expenditure.isAproved

                    };
                    employeesExpenditureVMs.Add(employeesExpenditureVM);
                }
            }
            return employeesExpenditureVMs;
            
        }

        public int UpdateByExpenditure(int id, EmployeesExpenditureVM employeesExpenditureVM)
        {
            Expenditure expenditure = managerRepository.GetExpenditureById(id);
            if (expenditure!=null)
            {
                expenditure.isAproved = employeesExpenditureVM.isAproved;
                return managerRepository.UpdatedExpenditure(expenditure);

            }
            return 0;
        }
    }
}
