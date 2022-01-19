using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract
{
  public  interface IEmployeeService
    {
        Employee CheckLogin(LoginVM login);
        List<Employee> GetListEmployees(int id);
        Employee AddEmployee(AddEmployeeVM employeeVM, int id, string mailextension);
    }
}
