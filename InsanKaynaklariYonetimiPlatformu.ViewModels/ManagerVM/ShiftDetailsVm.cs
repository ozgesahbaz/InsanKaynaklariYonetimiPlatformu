using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class ShiftDetailsVm
    {
        public int EmployeeID { get; set; }
        public string EmployeeFullName { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftFinishTime { get; set; }
        public DateTime RespiteStartTime { get; set; }
        public DateTime RespiteFinishTime { get; set; }
    
    }
}
