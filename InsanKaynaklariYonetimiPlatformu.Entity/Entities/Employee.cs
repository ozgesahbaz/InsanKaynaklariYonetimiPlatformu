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
            Expenditures = new HashSet<Expenditure>();
            Debits = new HashSet<Debit>();
            Shifts = new HashSet<Shift>();
        }
       
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Photo { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime StartDate { get; set; }

        public decimal? Salary { get; set; }
        public  int ManagerId { get; set; }
        public int ShiftID { get; set; }

       
        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual ICollection<Debit> Debits { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Expenditure> Expenditures { get; set; }
    }
}
