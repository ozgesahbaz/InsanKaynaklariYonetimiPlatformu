using InsanKaynaklariYonetimiPlatformu.DAL.Repositories;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.AdminVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.BLL.Services
{
    public class AdminService
    {
        AdminRepository adminRepository;
        public AdminService()
        {
            adminRepository = new AdminRepository();
        }
        public List<Company> GetListPassiveCompanies()
        {
            return adminRepository.GetListPassiveCompanies();
        }

        public Manager ActivateManager(int id)
        {
           return adminRepository.ActivateManager(id);
        }
    }
}
