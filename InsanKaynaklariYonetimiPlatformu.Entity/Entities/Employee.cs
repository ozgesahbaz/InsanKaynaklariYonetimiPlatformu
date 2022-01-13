using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
   public class Employee
    {
        public Employee()
        {
            Permissions = new HashSet<Permission>();
        }
     
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Surname { get; set; }
        public string Photo { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
      
        //Her employee için birden çok permission' a sahip olabilir.
        public virtual ICollection<Permission> Permissions { get; set; }
        
        //Her çalışanın bir manager'ı olacak
        public  int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
