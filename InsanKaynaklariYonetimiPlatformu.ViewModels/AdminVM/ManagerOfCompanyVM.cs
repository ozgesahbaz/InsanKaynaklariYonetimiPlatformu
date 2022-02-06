using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.AdminVM
{
    public class ManagerOfCompanyVM
    {
        public int CompanyID { get; set; }
        public int ManagerID { get; set; }

        public string CompanyName { get; set; }
        public string CompanyPhoto { get; set; }

        public string ManagerName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public bool IsApproved { get; set; }

    }
}
