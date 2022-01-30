   
using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EmployeesDebit (int id) 
        {
            return View();
        
        }
        [HttpPost]
        public IActionResult EmployeesDebit(int id, EmployeeDebitVM employeeDebitVM)
        {
            try
            {
                List<EmployeeDebitVM> debitVMs = employeeService.GetEmployeeDebitList(id);
                if (debitVMs != null)
                {
                    return View(debitVMs);
                }
                else
                {
                    throw new Exception("Henüz zimmetiniz bulunmamaktadır.");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return View();


        }
        public IActionResult MyPermissions(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult MyPermissions(int id, EmployeePermissionVM permissionVM)
        {
            try
            {
                if (employeeService.AddPermissionEmployee(id,permissionVM)<1)
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
        public IActionResult CreatePasswordByEmployeeMail(int id)
        {
            RegisterEmployeeVM register = new RegisterEmployeeVM()
            {
                ID = id
            };
            return View(register);
        }
        [HttpPost]
        public IActionResult CreatePasswordByEmployeeMail(RegisterEmployeeVM register)
        {
            try
            {
                if (register.Password == register.AgainPassword)
                {
                    Employee employee = employeeService.GetEmployeeById(register.ID);
                    if (employee!=null)
                    {
                        int AffectedRows= employeeService.ChangesPassword(employee, register.Password);
                        if (AffectedRows<=0)
                        {
                            throw new Exception("Bir hata oluştu.");
                        }
                    }
                }
                else
                {
                    throw new Exception("Parolalar uyuşmuyor.");
                }
            }
            catch (Exception ex)
            {
                 ModelState.AddModelError("exception", ex.Message);

            }

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult ExpenditureList(int id) 
        {
            return View();
        }
        [HttpGet]
        public IActionResult RejectedDebit (int id) 
        {
            try
            {
                Debit debit = employeeService.GetDebitById(id);
                if (debit== null)
                {
                    throw new Exception("Bir hata oluştu");
                }
                else
                {
                    EmployeeDebitVM employeeDebitVM = new EmployeeDebitVM()
                    {
                        DebitName = debit.DebitName,
                        DescofRejec = debit.DescofRejec,
                        ID = debit.ID
                        
                    };

                    return View(employeeDebitVM);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("EmployeesDebit");
        
        }
        [HttpPost]
        public IActionResult RejectedDebit (int id, EmployeeDebitVM employeeDebitVM) 
        {
            try
            {
                if (employeeService.ChangeRejectedDebit(id, employeeDebitVM)<1)
                {
                    throw new Exception("Bir hata oluştu");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("EmployeesDebit");
        
        
        }

        [HttpPost]
        public IActionResult ExpenditureList(int id, ExpenditureVM expenditureVM)
        {
            try
            {
                if (employeeService.AddExpenditure(id, expenditureVM) < 1)
                {
                    throw new Exception("Bir hata oluştu");

                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return View();

        }

        public IActionResult DeletedExpenditure(int id)
        {
            try
            {
                if (employeeService.RemoveExpenditure(id) < 1)
                {
                    throw new Exception("Bir hata oluştu");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("ExpenditureList");

        }


        public IActionResult AccountSetting(int id)
        {
            try
            {
                Employee employee = employeeService.GetEmployeeById(id);
                if (employee != null)
                {
                    AccountSettingVM settingVM = new AccountSettingVM()
                    {
                        PhotoPath = employee.Photo,
                        FullName = employee.FullName,
                        Email = employee.Email
                    };
                    return View(settingVM);

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
        public IActionResult AccountSetting(int id, AccountSettingVM accountSettingVM) 
        {
            try
            {
                Random rnd = new Random();
                string documentPath = null;

                if (accountSettingVM.Photo != null)
                {
                    string[] ext = accountSettingVM.Photo.ContentType.Split('/');
                    if (ext[1] == "jpeg" || ext[1] == "png")
                    {
                        string filename = $"img_employee{id}_{ext[0]}{rnd.Next(0, 10000)}.{ext[1]}";
                        string filepath = Path.Combine(Environment.CurrentDirectory, "wwwroot\\uploads\\image\\userphoto", filename);
                        documentPath = $"uploads\\image\\userphoto\\{filename}";
                        FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                        accountSettingVM.Photo.CopyTo(fs);
                        fs.Close();
                    }
                    else
                    {
                        throw new Exception("Lütfen jpeg veya png türünde bir fotoğraf yükleyiniz.");
                    }
                }
                if (employeeService.ChangeAccount(id, accountSettingVM, documentPath) > 0)
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
            Employee employee = employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                AccountSettingVM settingVM1 = new AccountSettingVM()
                {
                    PhotoPath = employee.Photo,
                    FullName = employee.FullName,
                    Email = employee.Email
                };
                HttpContext.Session.SetString("FullName", employee.FullName);
                HttpContext.Session.SetString("Photo", employee.Photo);
                return View(settingVM1);
             
            }

            return View();
        }

        [HttpGet]
        public IActionResult ExpenditureDocuments(int id)
        {
            AddExpenditureDocumentVM expenditureDocumentVM = new AddExpenditureDocumentVM()
            {
                ID = id
            };
            return View(expenditureDocumentVM);
        }

        [HttpPost]
        public IActionResult ExpenditureDocuments(int id, AddExpenditureDocumentVM expenditureDocumentVM)
        {
            try
            {
                string ext = expenditureDocumentVM.File.ContentType.Split('/')[1];
                if (ext == "pdf")
                {
                    string filename = $"file_expenditure{id}_{expenditureDocumentVM.FileName}.{ext}";
                    string filepath = Path.Combine(Environment.CurrentDirectory, "wwwroot\\uploads\\ExpenditureFile", filename);
                    string documentPath = $"uploads\\ExpenditureFile\\{filename}";
                    if (employeeService.AnyFilePath(documentPath))
                    {
                        throw new Exception("Lütfen farklı bir dosya ismi giriniz.");
                    }
                    if (employeeService.AddDocumentByExpenditureID(id, documentPath, expenditureDocumentVM.FileName) < 1)//
                    {
                        throw new Exception("Bir hata oluştu.");
                    }
                    FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                    expenditureDocumentVM.File.CopyTo(fs);
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
            AddExpenditureDocumentVM expenditureDocumentVM1 = new AddExpenditureDocumentVM()
            {
                ID = id
            };

            return View(expenditureDocumentVM1);

        }

        public IActionResult DeletedDocument(int id)
        {
            try
            {
                if (employeeService.RemoveDocument(id) < 1)
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            catch (Exception ex)

            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("ExpenditureDocuments");
        }
    }

}
