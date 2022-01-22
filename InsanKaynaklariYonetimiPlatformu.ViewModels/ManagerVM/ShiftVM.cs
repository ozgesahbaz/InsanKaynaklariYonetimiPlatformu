using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
   public class ShiftVM
    {
        public ShiftVM()
        {
            List<RespiteVM> Respites = new List<RespiteVM>();
        }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftFinishTime { get; set; }

        public List<RespiteVM> Respites { get; set; }
    }
}
