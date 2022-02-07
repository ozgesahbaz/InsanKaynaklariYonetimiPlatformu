﻿using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class EditPremiumVm
    {
       
        public int EmployeeID { get; set; }
       
        public Employee Employee { get; set; }

        [Display(Name = "Maaş")]
        public decimal Salary { get; set; }
        [Display(Name = "Prim Oranı")]
        public decimal PremiumRate { get; set; }
      
        [Display(Name = "Toplam Maaş")]
        public decimal NetSalary { get; set; }


    }
}
