using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
    public class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }
        
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string MailExtension { get; set; }
        public string  CompanyLogo { get; set; }
        public DateTime RegisterDate { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Membership Membership { get; set; }
    }
}