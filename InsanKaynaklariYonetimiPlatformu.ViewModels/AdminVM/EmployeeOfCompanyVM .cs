using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.AdminVM
{
    public class EmployeeOfCompanyVM
    {

        public string FullName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }

        public bool IsApproved { get; set; }

        public string Statu { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime StartDate { get; set; }
    }
}
