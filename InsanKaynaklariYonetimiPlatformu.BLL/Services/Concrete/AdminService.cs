using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using InsanKaynaklariYonetimiPlatformu.ViewModels.AdminVM;
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
    public class AdminService : IAdminService
    {
        IAdminRepository adminRepository;

        public AdminService(IAdminRepository _adminRepository)
        {
            adminRepository = _adminRepository;

        }
        public List<Company> GetListPassiveCompanies()
        {
            return adminRepository.GetListPassiveCompanies();
        }

        public Manager ActivateManager(int id)
        {
            return adminRepository.ActivateManager(id);
        }

        public Admin CheckLogin(LoginVM login)
        {
            Admin admin = adminRepository.CheckLogin(login.Email, login.Password);
            if (admin != null)
            {
                return admin;

            }
            return null;
        }

        public List<CommentVM> GetComments()
        {
            List<Comment> comments = adminRepository.GetComments();
            List<CommentVM> commentVMs = new List<CommentVM>();
            if (comments != null)
            {
                foreach (Comment comment in comments)
                {
                    CommentVM commentVM = new CommentVM()
                    {
                        Comment = comment.Description,
                        CommentID = comment.CommentId,
                        ManagerFullName = comment.Manager.FullName,
                        ManagerPhoto = comment.Manager.Photo
                    };
                    commentVMs.Add(commentVM);

                }
            }
            return commentVMs;
        }

        public List<ActiveCompanyVM> GetActiveCompanyList()
        {
            List<Company> companies = adminRepository.GetListActiveCompanies();
            if (companies != null)
            {

                List<ActiveCompanyVM> companyVMs = new List<ActiveCompanyVM>();
                foreach (Company company in companies)
                {

                    ActiveCompanyVM companyVM = new ActiveCompanyVM();

                    companyVM.CompanyId = company.CompanyId;
                    companyVM.CompanyName = company.CompanyName;
                    companyVM.ManagerID = company.Manager.ManagerId;
                    companyVM.ManagerFullName = company.Manager.FullName;
                    companyVM.ManagerMail = company.Manager.Email;
                    companyVM.Mailextension = company.MailExtension;
                    companyVM.membershipType = company.Membership.MembershipType;
                    companyVM.RegisterDate = company.RegisterDate;
                    //kayıt türüne göre kayıt bitiş tarihi bulunuyor
                    if (company.Membership.MembershipType == MembershipType.Yıllık)
                    {
                        companyVM.FinishedDate = company.RegisterDate.AddYears(1);
                    }
                    else if (company.Membership.MembershipType == MembershipType.Aylık)
                    {
                        companyVM.FinishedDate = company.RegisterDate.AddMonths(1);
                    }
                    //bitiş tarihi bugünden küççük veya eşitse servicede şirketi pasifleştirme methoduna gönderiliyor.
                    if (companyVM.FinishedDate <= DateTime.Today)
                    {
                        if (DeactivateCompanies(companyVM) < 0)
                        {
                            throw new Exception("Bir hata oluştu.");
                        }

                    }
                    else
                    {
                        companyVMs.Add(companyVM);
                    }
                }
                return companyVMs;
            }
            return null;
        }

        public int DeactivateCompanies(ActiveCompanyVM companyVM)
        {
           
            Manager manager = adminRepository.GetManagerByID(companyVM.CompanyId);
            List<Employee> employees = adminRepository.GetEmployeeByManagerID(manager.ManagerId);
            manager.IsActive = false;
            manager.IsApproved = false;
            foreach (Employee employee in employees)
            {
                employee.IsActive = false;
            }
            SendMail(manager);
            return adminRepository.Save();
        }

        private static void SendMail(Manager manager)
        {
            MailMessage msg = new MailMessage();
            msg.Subject = "Üyeliğiniz sonlanmıştırç.";
            msg.From = new MailAddress("redteamproje@outlook.com");
            msg.To.Add(new MailAddress(manager.Email));
            msg.IsBodyHtml = true;
            msg.Body = $"<h1 style='font-size:28px;font-weight:300;line-height:150%;margin:0;text-align:center;color:black;background-color:inherit'>Merhabalar</h1>Sayın { manager.FullName} üyeliğiniz sonlanmıştır.Sitemizin ayrıcalıklarından yararlanmaya devam etmek için lütfen bizimle bu mail adresi üzerinden iletişime geçiniz.";

            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
            NetworkCredential AccountInfo = new NetworkCredential("redteamproje@outlook.com", "123toci123");
            smtp.UseDefaultCredentials = false; //Standart doğrulama kullanılsın mı? -> Yalnızca gönderici özellikle istiyor ise TRUE işaretlenir.
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true;
            smtp.Send(msg);

        }

        public int DeleteCompany(int id)
        {
            //Şirketi bul
            Company company = adminRepository.GetCompanyById(id);
            if (company != null)
            {
                //şirketin managerini bul
                Manager manager = adminRepository.GetManagerByID(company.Manager.ManagerId);
                if (manager != null)
                {

                    //managerid eşit olan debitleri bul(employeelarının ve managerin kendi debitlerini bir listede toplaması için managerıd ile çağırıldı)
                    List<Debit> debits = adminRepository.GetDebitByManagerID(manager.ManagerId);
                    if (debits.Count!= 0)
                    {//debit varsa debitleri sil.
                        foreach (Debit debit in debits)
                        {
                            if (adminRepository.DebitRemove(debit) < 1)
                            {
                                throw new Exception("Bir hata oluştu");
                            }
                        }

                    }
                    //managerid eşit olan harcama bul
                    List<Expenditure> expenditures = adminRepository.GetExpenditureByManagerID(manager.ManagerId);
                    if (expenditures.Count!=0)
                    {
                        foreach (Expenditure expenditure in expenditures)
                        {
                            //expenditure varsa dökümanlarını bul
                            List<ExpenditureDocument> expenditureDocuments = adminRepository.GetExpenditureDocumentByexpenditureID(expenditure.ID);
                            if (expenditureDocuments.Count != 0)
                            {
                                foreach (ExpenditureDocument document in expenditureDocuments)
                                {

                                    if (adminRepository.expenditureDocumentsRemove(document) < 1)
                                    {
                                        throw new Exception("Bir hata oluştu");
                                    }
                                }
                                //döküman varsa sil.

                            }
                            if (adminRepository.ExpenditureRemove(expenditure) < 1)
                            {
                                throw new Exception("Bir hata oluştu");
                            }

                        }

                    }
                    //managerid eşit olan izin bul
                    List<Permission> permissions = adminRepository.GetPermissionByManagerID(manager.ManagerId);
                    if (permissions.Count != 0)
                    {//izin varsa sil.
                        foreach (Permission permission in permissions)
                        {
                            if (adminRepository.PermissionRemove(permission) < 1)
                            {
                                throw new Exception("Bir hata oluştu");
                            }
                        }

                    }



                    //managerin employelerini bul
                    List<Employee> employees = adminRepository.GetEmployeeByManagerID(manager.ManagerId);
                    if (employees.Count != 0)
                    {
                        foreach (Employee employee in employees)
                        {
                            //employee shifleri bul.
                            List<Shift> shifts = adminRepository.GetShiftByEmployeeID(employee.EmployeeId);
                            if (shifts.Count != 0)
                            {
                                foreach (Shift shift in shifts)
                                {
                                    //shift respitları bul
                                    List<Respite> respites = adminRepository.GetRespiteByShiftID(shift.ShiftId);
                                    if (respites.Count != 0)
                                    {
                                        foreach (Respite respite in respites)
                                        {
                                            //respite sil
                                            if (adminRepository.RespiteRemove(respite) < 1)
                                            {
                                                throw new Exception("Bir hata oluştu");
                                            }
                                        }
                                    }
                                    //shift sil
                                    if (adminRepository.ShiftRemove(shift) < 1)
                                    {
                                        throw new Exception("Bir hata oluştu");
                                    }


                                }


                            }
                            //employee documentları bul
                            List<Document> documents = adminRepository.GetDocumentByEmployeeID(employee.EmployeeId);
                            if (documents.Count != 0)
                            {
                                foreach (Document document in documents)
                                {
                                    //dokumanları sil
                                    if (adminRepository.DocumentRemove(document) < 1)
                                    {
                                        throw new Exception("Bir hata oluştu");
                                    }



                                }


                            }


                            //employee sil
                            if (adminRepository.EmployeeRemove(employee) < 1)
                            {
                                throw new Exception("Bir hata oluştu");

                            }
                        }
                    }
                    List<Comment> comments = adminRepository.GetCommentByManagerId(manager.ManagerId);
                    //manager yorumlar ı sil
                    if (comments.Count != 0)
                    {
                        foreach (Comment comment in comments)
                        {

                            if (adminRepository.CommentRemove(comment) < 1)
                            {
                                throw new Exception("Bir hata oluştu");

                            }
                        }
                    }
                    //manager sil
                    if (adminRepository.ManagerRemove(manager) < 1)
                    {
                        throw new Exception("Bir hata oluştu");

                    }

                    //şirketi sil
                }
                return adminRepository.CompanyRemove(company);

            }
            else
            {
                throw new Exception("Bir hata oluştu");

            }

        }
    }
}
