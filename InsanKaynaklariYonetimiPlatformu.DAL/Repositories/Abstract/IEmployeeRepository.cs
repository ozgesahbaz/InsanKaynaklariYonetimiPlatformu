using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        Employee CheckLogin(string email, string password);
        List<Employee> GetListEmployeesByManagerID(int id);
    }
}
