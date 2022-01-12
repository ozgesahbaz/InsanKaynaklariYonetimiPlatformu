using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string MailExtension { get; set; }
        public string CompanyLogo { get; set; }

        public int ManagerId { get; set; }
        public int MembershipId { get; set; }
   
    }
}