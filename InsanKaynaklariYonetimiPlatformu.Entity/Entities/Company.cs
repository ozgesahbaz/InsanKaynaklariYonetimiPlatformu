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
        public string CompanyLogo { get; set; }

        //Company Employee ilişisi yapılması doğru mu emin olamadım kontrol edilmeli

        public ICollection<Employee> Employees { get; set; }

        //Her company için bir manager
        //public int ManagerId { get; set; }
        public  Manager Manager { get; set; }

        //Her company için bir üyelik
        //public int MembershipId { get; set; }
        public Membership Membership { get; set; }
    }
}