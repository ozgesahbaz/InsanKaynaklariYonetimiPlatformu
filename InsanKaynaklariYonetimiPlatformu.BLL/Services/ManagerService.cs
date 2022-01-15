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

namespace InsanKaynaklariYonetimiPlatformu.BLL.Services
{
    public class ManagerService
    {
        ManagerRepository managerRepository;
        public ManagerService()
        {
            managerRepository = new ManagerRepository();
        }
        public Company AddCompany(string companyName, string managerMail)
        {
            string mailextension = GetMailExtension(managerMail);
            if (managerRepository.AnyMailExtension(mailextension))
            {
                throw new Exception("Bu şirket zaten kayıtlı.");
            }
            Company company = new Company()
            {
                CompanyName = companyName,
                MailExtension = mailextension
            };
            if (managerRepository.InsertCompany(company) > 0)
            {
                return company;
            }
            else
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        private static string GetMailExtension(string managerMail)
        {
            string mailextension;
            string[] mailPart = managerMail.Split('@');
            string[] mailextensionPart = mailPart[1].Split('.');
            mailextension = mailextensionPart[0];
            return mailextension;
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
                FullName = register.ManagerFullName,
                CompanyId = company.CompanyId,
                //StatusType = StatusType.CompanyManager, // statustype propertisi kaldırıldı admin db olusturuldugundan 
                Password = register.ManagerPassword,
                Email = register.ManagerMail,
                IsActive=false,
                IsApproved=false
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

        public bool ManagerApproval(int id)
        {
           return managerRepository.managerApproval(id); // return komutu eklendi hata veriyordu
        }
    }
}
