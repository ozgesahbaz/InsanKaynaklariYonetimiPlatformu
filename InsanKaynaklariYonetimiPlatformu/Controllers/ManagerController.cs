﻿using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
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

        public IActionResult Index()
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
            msg.From = new MailAddress("redteamproje@outlook.com");
            msg.To.Add(new MailAddress(employee.Email));
            msg.IsBodyHtml = true;
            msg.Body = "<div style='background-color:#422222;margin:0;padding:30px 0;width:100%'>"
                + "<table border='0' cellpadding='0' cellspacing='0' height ='100%' width ='100%'>" +
                "<tbody><tr><td align='center'><div><p><img alt='RedTeam' src = 'https://images-workbench.99static.com/esuZwLTC22_Jl0Q7BUlzmr_NHFI=/99designs-contests-attachments/83/83773/attachment_83773038' style ='width:100px; transform:  rotate(90deg; height:20;'></p></div>" +
                  $"<table border='0' cellpadding='0' cellspacing ='0' width='600'  style='background-color:#ffffff;border:1px solid #d8e2ef;border-radius:10px; padding-bottom:5%;'><tbody><tr><td align ='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' style='background-image: linear-gradient(to bottom right, red, white);border-bottom:0;font-weight:bold;line-height:100%;vertical-align:middle;border-radius:10px 10px 0 0'><tbody><tr><td style='padding:25px 48px;display:block'><h1 style='font-size:28px;font-weight:300;line-height:150%;margin:0;text-align:center;color:black;background-color:inherit'>Hoşgeldiniz!</h1></td></tr></tbody></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' id='m_8132288392641734257template_body' style ='background-color:#ffffff;border-radius:10px'><tbody><tr><td valign='top' id='m_8132288392641734257body_content'><table border='0' cellpadding='20' cellspacing='0' width='100%'><tbody><tr><td valign='top' style='padding:48px 48px 48px'><div style='color:#636363;font-size:14px;line-height:150%;text-align:left'><p style='margin:0 0 16px;text-align:center'>Sayın {employee.FullName} Kayıt olduğunuz için teşekkür ederiz. Aşağıdaki butona tıkladığınızda hesabınız aktif edilecek ve hizmetlerimizden yararlanmaya başlayacaksınız.<strong></strong></p><div style='text-align:center'><a href='http://localhost:8021/Employe/CreatePasswordByEmployeeMail/{employee.EmployeeId}' style='background:red;color:BLACK;text-align:center;padding:6px 20px;font-size:19px;line-height:28px;display:inline-block;text-decoration:none;border-radius:5px;border:1px solid burlywood;background-image:linear-gradient(180deg,rgba(255,255,255,0.15),rgba(255,255,255,0))'>Aktivasyon İçin Tıklayın</a></div></div></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='10' cellspacing='0' width='200'><tbody><tr><td valign='top' style='padding:0;border-radius:6px'><table border='0' cellpadding='10' cellspacing ='0' width='100%'><tbody><tr><td colspan='2' valign='middle' style='border-radius:6px;border:0;color:#8a8a8a;font-size:12px;text-align:center;padding:24px 0'><p style='margin:0 0 16px'><strong>Red Team</strong><br>Kadıköy<br>via Bilge Adam<br></p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></div>";


            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
            NetworkCredential AccountInfo = new NetworkCredential("redteamproje@outlook.com", "123toci123");
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
            return View();


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
                    return RedirectToAction("EmployeesPermissionRequest", "Manager");
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
            return RedirectToAction("ManagersDebit");
        }
        [HttpGet]
        public IActionResult ShiftDetails(int id)
        {
       
            List<Employee> employees = employeeService.GetListEmployees(id);
            ShiftDetailsVM shiftDetailsVM = new ShiftDetailsVM()
            {
                Employees = employees,
            };

            return View(shiftDetailsVM);
        }
        [HttpPost]
        public IActionResult ShiftDetails(ShiftDetailsVM shiftDetailsVM, int id)
        {
            managerService.AddShiftDetails(shiftDetailsVM, id);
            shiftDetailsVM.Employees = employeeService.GetListEmployees(id);
            return View(shiftDetailsVM);
        }
        [HttpGet]
        public IActionResult ManagersPermission(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult ManagersPermission(int id, ManagersPermissionVM permissionVM)
        {
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

            return View();
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
<<<<<<< HEAD
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
                    if (employeeService.AddDocumentByEmployeID(id, documentPath,documentVM.FileName) <1)//
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
=======

       
>>>>>>> 89c2566440810fc7606c490cdfb1b4aab793a1ee
    }


}

