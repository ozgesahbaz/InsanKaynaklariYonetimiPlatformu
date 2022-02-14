﻿using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace InsanKaynaklariYonetimiPlatformu.UI.Controllers
{
    public class ManagerController : Controller
    {
        IManagerService managerService;
        IEmployeeService employeeService;

        public ManagerController(IManagerService _managerService, IEmployeeService _employeeService)
        {
            managerService = _managerService;
            employeeService = _employeeService;
        }
        public IActionResult Index(int id)
        {

           
            return View();
        }
        [HttpGet]
        public IActionResult ManagersEmployees(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditPersonal(int id)
        {
            Employee employee = employeeService.GetEmployeeById(id);

            return View(employee);
        }
        [HttpPost]
        public IActionResult EditPersonal(int id, Employee employee)
        {
            try
            {
                int affectedRows = employeeService.UpdateEmployees(id, employee);
                if (affectedRows > 0)
                {
                    return RedirectToAction("ManagersEmployees", "Manager");
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }

            return View(employee);
        }
        [HttpPost]
        public IActionResult ManagersEmployees(AddEmployeeVM employeeVM, int id)
        {
           
            try
            {
                int dateTime = employeeVM.BirtDay.Year;
                int StartDate = employeeVM.StartDate.Year;
                if (DateTime.Now.Year - employeeVM.BirtDay.Year < 18)
                {
                    throw new Exception("18 yaşından küçük çalışan ekleyemezsiniz.");
                }
                //işe giriş tarihi kontrolü
                else if (StartDate <dateTime+18)
                {
                    throw new Exception("Başlangıç tarihini güncelleyiniz");
                }
                //mail uzantısı controlü için şirket manager id(layouttaki sessiondan geldi) ile bulundu.
                Company company = managerService.FindCompanyByManagerID(id);
                //çalışan eklendi. kontroller employee servicede (controller->services->repository)
                Employee employee = employeeService.AddEmployee(employeeVM, id, company.MailExtension);
                //oluştuysa employee dolu gelecek.
                if (employee != null)
                {
                    SendMail(employee);
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
        public void SendMail(Employee employee)
        {
            MailMessage msg = new MailMessage();
            msg.Subject = "Üyeliğinizi doğrulayın.";
            msg.From = new MailAddress("readteamproject1@outlook.com");
            msg.To.Add(new MailAddress(employee.Email));
            msg.IsBodyHtml = true;
            msg.Body = "<div style='background-color:#422222;margin:0;padding:30px 0;width:100%'>"
                + "<table border='0' cellpadding='0' cellspacing='0' height ='100%' width ='100%'>" +
                "<tbody><tr><td align='center'><div><p><img alt='RedTeam' src = 'https://images-workbench.99static.com/esuZwLTC22_Jl0Q7BUlzmr_NHFI=/99designs-contests-attachments/83/83773/attachment_83773038' style ='width:100px; transform:  rotate(90deg; height:20;'></p></div>" +
                  $"<table border='0' cellpadding='0' cellspacing ='0' width='600'  style='background-color:#ffffff;border:1px solid #d8e2ef;border-radius:10px; padding-bottom:5%;'><tbody><tr><td align ='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' style='background-image: linear-gradient(to bottom right, red, white);border-bottom:0;font-weight:bold;line-height:100%;vertical-align:middle;border-radius:10px 10px 0 0'><tbody><tr><td style='padding:25px 48px;display:block'><h1 style='font-size:28px;font-weight:300;line-height:150%;margin:0;text-align:center;color:black;background-color:inherit'>Hoşgeldiniz!</h1></td></tr></tbody></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' id='m_8132288392641734257template_body' style ='background-color:#ffffff;border-radius:10px'><tbody><tr><td valign='top' id='m_8132288392641734257body_content'><table border='0' cellpadding='20' cellspacing='0' width='100%'><tbody><tr><td valign='top' style='padding:48px 48px 48px'><div style='color:#636363;font-size:14px;line-height:150%;text-align:left'><p style='margin:0 0 16px;text-align:center'>Sayın {employee.FullName} Kayıt olduğunuz için teşekkür ederiz. Aşağıdaki butona tıkladığınızda hesabınız aktif edilecek ve hizmetlerimizden yararlanmaya başlayacaksınız.<strong></strong></p><div style='text-align:center'><a href='http://localhost:8021/Employee/CreatePasswordByEmployeeMail/{employee.EmployeeId}' style='background:red;color:BLACK;text-align:center;padding:6px 20px;font-size:19px;line-height:28px;display:inline-block;text-decoration:none;border-radius:5px;border:1px solid burlywood;background-image:linear-gradient(180deg,rgba(255,255,255,0.15),rgba(255,255,255,0))'>Aktivasyon İçin Tıklayın</a></div></div></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='10' cellspacing='0' width='200'><tbody><tr><td valign='top' style='padding:0;border-radius:6px'><table border='0' cellpadding='10' cellspacing ='0' width='100%'><tbody><tr><td colspan='2' valign='middle' style='border-radius:6px;border:0;color:#8a8a8a;font-size:12px;text-align:center;padding:24px 0'><p style='margin:0 0 16px'><strong>Red Team</strong><br>Kadıköy<br>via Bilge Adam<br></p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></div>";


            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
            NetworkCredential AccountInfo = new NetworkCredential("readteamproject1@outlook.com", "123toci123");
            smtp.UseDefaultCredentials = false; //Standart doğrulama kullanılsın mı? -> Yalnızca gönderici özellikle istiyor ise TRUE işaretlenir.
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true;


            smtp.Send(msg);
        }
        [HttpGet]
        public IActionResult ManagersPersonelDebit(int id)
        {
            return View();

        }
        [HttpPost]
        public IActionResult ManagersPersonelDebit(int id, ManagersDebitVM managersDebitVM)
        {
            try
            {
                if (managerService.AddManagersPersonelDebit(id, managersDebitVM) < 1)
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            return View();


        }
        [HttpGet]
        public IActionResult ManagersEmployeeDebit(int id)
        {
            List<Employee> employees = employeeService.GetListEmployees(id);
            AddEmployeesDebitVM debitforEmployees = new AddEmployeesDebitVM()
            {
                Employees = employees
            };
            return View(debitforEmployees);
        }
        [HttpPost]
        public IActionResult ManagersEmployeeDebit(int id, AddEmployeesDebitVM debitVM)
        {
            try
            {
                if (managerService.AddEmployeesDebit(id, debitVM) > 0)
                {
                    return RedirectToAction("ManagersEmployeeDebit", "Manager");
                }
                else
                {
                    throw new Exception("Bir Hata Oluştu");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Exception", ex.Message);
            }
            //Ekleme yapamazsa sayfaya geri döndür hatayı gösteriyor.
            List<Employee> employees = employeeService.GetListEmployees(id);
            AddEmployeesDebitVM debitforEmployees = new AddEmployeesDebitVM()
            {
                Employees = employees
            };
            return View(debitforEmployees);


        }
        [HttpGet]
        public IActionResult Register(/*ManagerRegisterVM register*/)
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = employeeService.GetEmployeeById(id);
            DeleteEmployeVM deleteEmploye = new DeleteEmployeVM()
            {
                id = employee.EmployeeId,
                FullName = employee.FullName
            };

            return View(deleteEmploye);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(DeleteEmployeVM deleteEmploye)
        {
            try
            {
                int affectedRows = employeeService.DeleteEmployee(deleteEmploye.id);
                if (affectedRows > 0)
                {
                    return RedirectToAction("ManagersEmployees", "Manager");
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
        public IActionResult StopDeleteEmployee (int id) 
        {
         return RedirectToAction("ManagersEmployees");
        }
        [HttpPost]
        public IActionResult Register(ManagerRegisterVM register)
        {
            //Vm buraya gelecek isvalid kontrolü yapılacak

            if (ModelState.IsValid)
            {

                try
                {
                    Company company = managerService.AddCompany(register.CompanyName, register.ManagerMail, register.Membership, register.Address);
                    Manager manager;
                    if (company.CompanyId > 0)
                    {
                        manager = managerService.AddManager(register, company);
                        if (manager.ManagerId > 0)
                        {

                            throw new Exception("Kayıdınız onaylandığında mail adresinize doğrulama linki gönderilecektir. Linke tıklayarak mailinizi doğrulayabilirsiniz.");

                        }
                    }

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("exception", ex.Message);
                }
            }

            return View(register);
        }
        public IActionResult ApprovalPage(int id)
        {

            try
            {
                if (managerService.ManagerApproval(id))
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return View();

        }
        [HttpGet]
        public IActionResult EmployeesPermissionRequest(int id)
        {
            List<Employee> employees = employeeService.GetListEmployees(id);
            AddEmployeesPermissionVM permissionforEmployees = new AddEmployeesPermissionVM()
            {
                Employees = employees
            };
            return View(permissionforEmployees);
        }
        [HttpPost]
        public IActionResult EmployeesPermissionRequest(AddEmployeesPermissionVM permissionVM, int id)
        {
            try
            {
                if (employeeService.AnyEmployeesPermission(permissionVM))
                {
                    throw new Exception("Çalışanın bu tarihlerde zaten onaylanmış izni bulunmaktadır.");
                }
                if (managerService.AddPermissionEmployee(permissionVM, id) > 0)
                {
                    return RedirectToAction("EmployeesPermissionRequest");
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            List<Employee> employees = employeeService.GetListEmployees(id);
            AddEmployeesPermissionVM permissionforEmployees = new AddEmployeesPermissionVM()
            {
                Employees = employees
            };
            return View(permissionforEmployees);

        }
        public IActionResult PermissionUpdated(int id)
        {
            try
            {
                PermissionVM permission = managerService.GetPermissionById(id);
                if (permission != null)
                {
                    return View(permission);
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }

            return View();
        }
        [HttpPost]
        public IActionResult PermissionUpdated(PermissionVM permissionVM)
        {
            try
            {
                if (managerService.UpdatePermission(permissionVM) < 1)
                {
                    throw new Exception("Bir hata oluştu.");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);


            }
            return RedirectToAction("EmployeesPermissionRequest");
        }
        public IActionResult DeletedPermission(int id)
        {
            try
            {
                if (managerService.RemovePermission(id) < 1)
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }

            return RedirectToAction("EmployeesPermissionRequest");
        }
        public IActionResult DeletedPermissionManager(int id)
        {
            try
            {
                if (managerService.RemovePermission(id) < 1)
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }

            return RedirectToAction("ManagersPermission");
        }
        public IActionResult DeletedManagersDebit(int id) 
        {
            try
            {
                if (managerService.RemoveDebit(id) < 1)
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("ManagersPersonelDebit");
        }
        [HttpGet]
        [ActionName("ShiftDetails")]
        public IActionResult Get(int id)
        {

            List<Employee> employees = employeeService.GetListEmployees(id);

            ShiftDetailsVM shiftDetailsVM = new ShiftDetailsVM()
            {
                Employees = employees,
                ManagerID = id,
            };

            return View(shiftDetailsVM);
        }
        [HttpPost]
        [ActionName("ShiftDetails")]
        public IActionResult Post(ShiftDetailsVM shiftDetailsVM, int id)
        {
            managerService.AddShiftDetails(shiftDetailsVM, id);
            shiftDetailsVM.Employees = employeeService.GetListEmployees(id);
            shiftDetailsVM.ManagerID = id;

            return View(shiftDetailsVM);
        }
        [HttpGet]
        public IActionResult DeleteShiftDetails(int id)
        {
            try
            {
                if (managerService.DeleteShiftDetails(id))

                {
                    return RedirectToAction("ShiftDetails");
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("ShiftDetails");




        }
        [HttpGet]
        public IActionResult GetEditShiftDetails(ShiftDetailsVM shiftDetailsVM, int id)
        {

            shiftDetailsVM = managerService.GetShiftDetailbyRespiteID(shiftDetailsVM, id);



            return View(shiftDetailsVM);

        }
        [HttpPost]
        public IActionResult PostEditShiftDetails(ShiftDetailsVM shiftDetailsVM, int id)
        {
            if (!managerService.EditShiftDetails(shiftDetailsVM, id))
            {
                throw new Exception("Bir hata oluştu.");
            }
            else
            {

                return RedirectToAction("ShiftDetails");
            }

        }
        [HttpGet]
        public IActionResult ManagersPermission(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult ManagersPermission(int id, ManagersPermissionVM permissionVM)
        {
            if (permissionVM.PermissionType==null)
            {
                throw new Exception("İzin tipi boş geçilemez");
                return View();
            }
            
            
                try
                {
                    if (managerService.AddManagersPermission(id, permissionVM) < 1)
                    {
                        throw new Exception("Bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("exception", ex.Message);

                }
                return View();

          
           
           
        }
        [HttpGet]
        public IActionResult ManagerPermissionUpdated(int id)
        {
            try
            {
                ManagersPermissionVM permissionVM = managerService.UpdatePermissionManager(id);
                if (permissionVM != null)
                {

                    return View(permissionVM);
                }
                else
                {
                    throw new Exception("Bir hata oluştur");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }

            return View();
        }
        [HttpPost]
        public IActionResult ManagerPermissionUpdated(int id, ManagersPermissionVM permissionVM)
        {
            try
            {
                if (managerService.UpdatePermissionManager(id, permissionVM) > 0)
                {
                    return RedirectToAction("ManagersPermission");
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }

            ManagersPermissionVM permissionVM1 = managerService.UpdatePermissionManager(id);



            return View(permissionVM1);

        }
        public IActionResult DeletedDebit(int id)
        {
            try
            {
                if (managerService.RemoveDebit(id) < 1)
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            catch (Exception ex)

            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("ManagersEmployeeDebit");
        }
        public IActionResult DeletedDocument(int id)
        {
            try
            {
                if (managerService.RemoveDocument(id) < 1)
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            catch (Exception ex)

            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("EmployeesDocuments");
        }
        [HttpGet]
        public IActionResult EmployeesDocuments(int id)
        {
            AddDocumentVM documentVM = new AddDocumentVM()
            {
                EmployeeID = id
            };
            return View(documentVM);
        }
        [HttpPost]
        public IActionResult EmployeesDocuments(int id, AddDocumentVM documentVM)
        {
            try
            {
                string ext = documentVM.File.ContentType.Split('/')[1];
                if (ext == "pdf")
                {
                    string filename = $"file_employee{id}_{documentVM.FileName}.{ext}";
                    string filepath = Path.Combine(Environment.CurrentDirectory, "wwwroot\\uploads\\file", filename);
                    string documentPath = $"uploads\\file\\{filename}";
                    if (employeeService.AnyFilePath(documentPath))
                    {
                        throw new Exception("Lütfen farklı bir dosya ismi giriniz.");
                    }
                    if (employeeService.AddDocumentByEmployeID(id, documentPath, documentVM.FileName) < 1)//
                    {
                        throw new Exception("Bir hata oluştu.");
                    }
                    FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                    documentVM.File.CopyTo(fs);
                    fs.Close();
                }
                else
                {
                    throw new Exception("Lütfen .pdf tipinde dosya yüklemesi yapınız.");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            AddDocumentVM documentVMd = new AddDocumentVM()
            {
                EmployeeID = id
            };

            return View(documentVMd);
        }
        [HttpGet]
        public IActionResult GetEditPremiumModel(int id)
        {
            EditPremiumVm editPremiumVm = new EditPremiumVm()
            {
                EmployeeID = id,
                Employee = employeeService.GetEmployeeById(id),
                Salary = employeeService.GetSalarybyEmployeeId(id),
                PremiumRate = employeeService.GetPremiumRateByEmployeeId(id),
                NetSalary = employeeService.GetNetSalaryByEmployeeId(id),
            };
            return View(editPremiumVm);
        }
        [HttpPost]
        public IActionResult PostEditPremiumModel(EditPremiumVm editPremiumVm, int id)
        {
            if (managerService.UpdatePremium(editPremiumVm, id))
            {
                return RedirectToAction("ManagersEmployees");

            }
            throw new Exception("Güncelleme başarısız oldu");

        }
        public IActionResult ChangePassword(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(int id, PasswordVM passwordVM)
        {
            try
            {
                if (managerService.ChangePassword(id, passwordVM) < 1)
                {
                    throw new Exception("Bir hata oluştu");
                }
                else
                {
                    throw new Exception("Şifreniz başarılı bir şekilde değiştirildi.");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
        public IActionResult AccountSettings(int id)
        {
            try
            {
                Manager manager = managerService.FindManager(id);
                if (manager != null)
                {
                    AccountSettingsVM settingsVM = new AccountSettingsVM()
                    {
                        PhotoPath = manager.Photo,
                        FullName = manager.FullName,
                        Email = manager.Email
                    };
                    return View(settingsVM);

                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
        [HttpPost]
        public IActionResult AccountSettings(int id, AccountSettingsVM settingsVM)
        {
            try
            {
                Random rnd = new Random();
                string documentPath = null;

                if (settingsVM.Photo != null)
                {
                    string[] ext = settingsVM.Photo.ContentType.Split('/');
                    if (ext[1] == "jpeg" || ext[1] == "png")
                    {
                        string filename = $"img_manager{id}_{ext[0]}{rnd.Next(0, 10000)}.{ext[1]}";
                        string filepath = Path.Combine(Environment.CurrentDirectory, "wwwroot\\uploads\\image\\userphoto", filename);
                        documentPath = $"uploads\\\\image\\userphoto\\{filename}";
                        FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                        settingsVM.Photo.CopyTo(fs);
                        fs.Close();
                    }
                    else
                    {
                        throw new Exception("Lütfen jpeg veya png türünde bir fotoğraf yükleyiniz.");
                    }
                }
                if (managerService.ChangeAccount(id, settingsVM, documentPath) > 0)
                {
                    throw new Exception("İşleminiz başarılı bir şekilde gerçekleşti");
                }
                else
                {
                    throw new Exception("Bir hata oluştu");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }

            Manager manager = managerService.FindManager(id);
            if (manager != null)
            {
                AccountSettingsVM settingsVMl = new AccountSettingsVM()
                {
                    PhotoPath = manager.Photo,
                    FullName = manager.FullName,
                    Email = manager.Email
                };
                HttpContext.Session.SetString("FullName", manager.FullName);
                HttpContext.Session.SetString("Photo", manager.Photo);
                return View(settingsVMl);
            }
            return View();
        }
        public IActionResult CompanySettings(int id)
        {
            try
            {
                Company company = managerService.FindCompanyByManagerID(id);
                if (company != null)
                {
                    CompanySettingsVM settingsVM = new CompanySettingsVM()
                    {
                        LogoPath = company.CompanyLogo,
                        Adress = company.Address,
                        CompanyName = company.CompanyName,
                    };
                    return View(settingsVM);

                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
        [HttpPost]
        public IActionResult CompanySettings(int id, CompanySettingsVM settingsVM)
        {
            Company company = managerService.FindCompanyByManagerID(id);
            try
            {
                Random rnd = new Random();
                string documentPath = null;

                if (settingsVM.CompanyLogo != null)
                {
                    string[] ext = settingsVM.CompanyLogo.ContentType.Split('/');
                    if (ext[1] == "jpeg" || ext[1] == "png")
                    {
                        string filename = $"img_company{company.CompanyId}_{ext[0]}{rnd.Next(0, 10000)}.{ext[1]}";
                        string filepath = Path.Combine(Environment.CurrentDirectory, "wwwroot\\uploads\\image\\company", filename);
                        documentPath = $"uploads\\image\\company\\{filename}";
                        FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                        settingsVM.CompanyLogo.CopyTo(fs);
                        fs.Close();
                    }
                    else
                    {
                        throw new Exception("Lütfen jpeg veya png türünde bir fotoğraf yükleyiniz.");
                    }
                }
                if (managerService.ChangeCompanySettings(id, settingsVM, documentPath) > 0)
                {
                    throw new Exception("İşleminiz başarılı bir şekilde gerçekleşti");
                }
                else
                {
                    throw new Exception("Bir hata oluştu");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            if (company != null)
            {
                CompanySettingsVM settingsVM1 = new CompanySettingsVM()
                {
                    LogoPath = company.CompanyLogo,
                    Adress = company.Address,
                    CompanyName = company.CompanyName,
                };
                HttpContext.Session.SetString("CompanyName", company.CompanyName);
                HttpContext.Session.SetString("CompanyLogo", company.CompanyLogo);
                return View(settingsVM1);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Comment(int id)
        {
            id = HttpContext.Session.GetInt32("ID").Value;
            try
            {
                Manager manager = managerService.GetCommentByManagerId(id);
                Company company = managerService.FindCompanyByManagerID(id);
                if (manager != null && company != null)
                {
                    CommentVM commentVM = new CommentVM();
                    if (manager.Comment != null)
                    {
                        commentVM.Comment = manager.Comment.Description;
                        commentVM.CommentID = manager.Comment.CommentId;
                    }
                    else
                    {
                        commentVM.Comment = null;
                        commentVM.CommentID = 0;
                    }
                    commentVM.ManagerFullName = manager.FullName;
                    commentVM.CompanyName = company.CompanyName;
                    commentVM.ManagerID = manager.ManagerId;
                    commentVM.ManagerPhoto = manager.Photo;


                    return View(commentVM);

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
        [HttpPost]
        public IActionResult Comment(int id, CommentVM commentVM)
        {
            try
            {
                if (managerService.AddComment(commentVM, id))
                {
                    return RedirectToAction("Comment");
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
        public IActionResult DeletedComment(int id)
        {
            try
            {
                if (managerService.RemoveComment(id) > 0)
                {
                    return RedirectToAction("Comment");
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
        [HttpGet]
        public IActionResult ManagerExpenditureList(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult ManagerExpenditureList(int id, ManagerExpenditureVM managerExpenditureVM)
        {
            try
            {
                if (managerService.AddManagerExpenditure(id, managerExpenditureVM) < 1)
                {
                    throw new Exception("Bir Hata Oluştu");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ecxception", ex.Message);
            }
            return View();
        }
        public IActionResult DeletedExpenditure(int id)
        {
            try
            {
                if (managerService.RemoveExpenditure(id) < 1)
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            catch (Exception ex)

            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("ManagerExpenditureList");
        }
        [HttpGet]
        public IActionResult EmployeeExpenditure(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult EmployeeExpenditure(int id, EmployeesExpenditureVM employeesExpenditureVM)
        {
            try
            {

                if (managerService.UpdateByExpenditure(id, employeesExpenditureVM) < 1)
                {
                    throw new Exception("Henüz harcama isteği bulunmamakta");
                }
                else
                {
                    return RedirectToAction("EmployeeExpenditure");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return View();
        }
        [HttpGet]
        public IActionResult ManagerExpenditureDocument(int id)
        {
            AddManagerExpenditureDocumentVM addManagerExpenditureDocumentVM = new AddManagerExpenditureDocumentVM()
            {
                ID = id
            };
            return View(addManagerExpenditureDocumentVM);
        }
        [HttpPost]
        public IActionResult ManagerExpenditureDocument(int id, AddManagerExpenditureDocumentVM addManagerExpenditureDocumentVM)
        {
            try
            {
                string ext = addManagerExpenditureDocumentVM.File.ContentType.Split('/')[1];
                if (ext == "pdf")
                {
                    string filename = $"file_expenditure{id}_{addManagerExpenditureDocumentVM.FileName}.{ext}";
                    string filepath = Path.Combine(Environment.CurrentDirectory, "wwwroot\\uploads\\ExpenditureFile", filename);
                    string documentPath = $"uploads\\ExpenditureFile\\{filename}";
                    if (managerService.AnyFilePath(documentPath))
                    {
                        throw new Exception("Lütfen farklı bir dosya ismi giriniz.");
                    }
                    if (managerService.AddDocumentByExpenditureID(id, documentPath, addManagerExpenditureDocumentVM.FileName) < 1)//
                    {
                        throw new Exception("Bir hata oluştu.");
                    }
                    FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                    addManagerExpenditureDocumentVM.File.CopyTo(fs);
                    fs.Close();
                }
                else
                {
                    throw new Exception("Lütfen .pdf tipinde dosya yüklemesi yapınız.");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }
            AddManagerExpenditureDocumentVM addManagerExpenditureDocumentVM1 = new AddManagerExpenditureDocumentVM()
            {
                ID = id
            };
            return View(addManagerExpenditureDocumentVM1);
        }
        public IActionResult ExpenditureUpdated(int id)
        {
            try
            {
                EmployeesExpenditureVM employeesExpenditureVM = managerService.GetExpenditureByID(id);
                if (employeesExpenditureVM != null)
                {
                    return View(employeesExpenditureVM);
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);

            }

            return View();
        }
        [HttpPost]
        public IActionResult ExpenditureUpdated(EmployeesExpenditureVM employeesExpenditureVM)
        {
            try
            {
                if (managerService.UpdateExpenditure(employeesExpenditureVM) < 1)
                {
                    throw new Exception("Bir hata oluştu.");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);


            }
            return RedirectToAction("EmployeeExpenditure");

        }
        //[HttpGet]
        //public IActionResult ExpenditureReject (int id) 
        //{
        //    try
        //    {
        //        EmployeesExpenditureVM employeesExpenditureVM = managerService.GetExpenditureById(id);
        //        if (employeesExpenditureVM != null)
        //        {
        //            return View(employeesExpenditureVM);
        //        }
        //        else
        //        {
        //            throw new Exception("Bir hata oluştu.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        ModelState.AddModelError("exception", ex.Message);

        //    }

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult ExpenditureReject(EmployeesExpenditureVM employeesExpenditureVM) 
        //{
        //    try
        //    {
        //        if (managerService.UpdateExpenditure(employeesExpenditureVM) < 1)
        //        {
        //            throw new Exception("Bir hata oluştu.");

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("exception", ex.Message);


        //    }
        //    return RedirectToAction("EmployeeExpenditure");
        //}
        public IActionResult DeleteEmployeeExpenditure(int id)
        {
            try
            {
                if (managerService.RemoveEmployeeExpenditure(id) < 1)
                {
                    throw new Exception("Bir hata oluştu.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("EmployeeExpenditure");

        }
    }
}

