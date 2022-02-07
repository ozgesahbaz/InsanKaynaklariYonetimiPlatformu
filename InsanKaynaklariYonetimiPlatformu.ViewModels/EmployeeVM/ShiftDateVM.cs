using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM
{
    public class ShiftDateVM
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftFinishTime { get; set; }
        public DateTime RespiteStartTime { get; set; }
        public DateTime RespiteFinishTime{ get; set; }


    }
}
