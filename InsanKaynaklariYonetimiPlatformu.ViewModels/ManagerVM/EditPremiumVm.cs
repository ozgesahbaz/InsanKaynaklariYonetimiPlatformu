using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class EditPremiumVm
    {
        public EditPremiumVm()
        {
            Employees = new List<Employee>();
        }
        public int EmployeeID { get; set; }
        public List<Employee> Employees { get; set; }
        public decimal Salary { get; set; }
        public decimal PremiumRate { get; set; }
        private decimal _netSalary;

        public decimal NetSalary
        {
            get { return _netSalary; }
            set { _netSalary = Salary*(1+PremiumRate); }
        }

      

    }
}
