using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class AddEmployeesDebitVM
    {

        public int ManagerID { get; set; }
        public int? EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string DebitName { get; set; }
        public string Details { get; set; }
        public List<Employee> Employees { get; set; }
        [Display(Name = "Başlama Tarihi")]
        public DateTime StartedDate { get; set; }
        

        //public Employee Employee { get; set; }
        //public Manager Manager { get; set; }
    }
}
