using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
   public class EmployeesExpenditureVM
    {
       
        public int ID { get; set; }
        [DataType(DataType.Text)]
        public string ExpenditureName { get; set; }
        [DataType(DataType.Currency)]
        public decimal ExpenditureAmount { get; set; }
        [DataType(DataType.Text)]
        public string Details { get; set; }
        public bool? isAproved { get; set; }
        public string ExpenditureDocuments { get; set; }
    }
}
