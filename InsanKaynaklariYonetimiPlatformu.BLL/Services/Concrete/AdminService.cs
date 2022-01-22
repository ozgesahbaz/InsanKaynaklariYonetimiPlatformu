﻿using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.AdminVM;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
