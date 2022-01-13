using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
    public class Manager
    {
        public Manager()
        {
            Employees = new HashSet<Employee>();
            Permissions = new HashSet<Permission>();
        }
       
        public int ManagerId { get; set; }
        public string FullName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public StatusType StatusType { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }

        //Her manager bir admini olacak
        public int AdminId { get; set; }
        public  Admin Admin { get; set; }
        
        //Her manager bir company' e ait olacak
        public  int CompanyId { get; set; }
        public Company Company { get; set; }

        //Her manager birden çok çalışana sahip olacak
        public virtual ICollection<Employee> Employees { get; set; }

        //Her manager birden çok permission'u olacak
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
