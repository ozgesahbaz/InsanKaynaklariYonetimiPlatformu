using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class ShiftDetailsVM
    {
        public ShiftDetailsVM()
        {
            Employees=new List<Employee>();
        }
        public int RespiteID { get; set; }
        public int ShiftID { get; set; }
        public int ManagerID { get; set; }
        public int EmployeeID { get; set; }
        public List<Employee> Employees { get; set; }
       
        [Display(Name = "Personel adı")]
        public string EmployeeFullName { get; set; }
      
        [Display(Name = "Vardiya Başlama Zamanı")]
        public DateTime ShiftStartTime { get; set; }
        [Display(Name = "Vardiya Bitiş Zamanı")]
        public DateTime ShiftFinishTime { get; set; }
        [Display(Name = "Mola Başlama Zamanı")]
        public DateTime RespiteStartTime { get; set; }
        [Display(Name = "Mola Bitiş Zamanı")]
        public DateTime RespiteFinishTime { get; set; }


   


    }
}