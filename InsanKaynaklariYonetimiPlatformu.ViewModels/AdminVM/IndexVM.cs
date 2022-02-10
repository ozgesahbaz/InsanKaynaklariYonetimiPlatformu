using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.AdminVM
{
    public class IndexVM
    {
        public int EmployeeCount { get; set; }
        public int CompanyCount { get; set; }
        public int ManagerCount { get; set; }

        public DateTime RegisteredDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
