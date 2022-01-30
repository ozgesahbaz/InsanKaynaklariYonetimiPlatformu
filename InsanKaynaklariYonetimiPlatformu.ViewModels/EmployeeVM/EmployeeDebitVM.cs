using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM
{
    public class EmployeeDebitVM
    {
        public int ID { get; set; }
        public string DebitName{ get; set; }
        [DataType(DataType.Text)]
        public string Details { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartedDate { get; set; }
             


        [DataType(DataType.Text)]
        public string DescofRejec { get; set; }
      
        public bool? IsAproved { get; set; }
    }
}
