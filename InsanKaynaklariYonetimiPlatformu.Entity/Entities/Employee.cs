using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity
{
   public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Surname { get; set; }
        public string Photo { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public int ManagerId { get; set; }
        public ICollection<Permission> Permissions { get; set; }

    }
}
