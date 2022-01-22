using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract
{
    public interface IAdminRepository
    {
        List<Company> GetListPassiveCompanies();


        Manager ActivateManager(int id);
        Admin CheckLogin(string email, string password);
    }
}
