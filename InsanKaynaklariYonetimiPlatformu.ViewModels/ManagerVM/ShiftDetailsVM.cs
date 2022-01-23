using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
   public class ShiftDetailsVM
    {
        public ShiftDetailsVM()
        {
            List<ShiftDetailsVM> Respites = new List<ShiftDetailsVM>();
        }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftFinishTime { get; set; }
        public int? ShiftId { get; set; }
        public int EmployedId { get; set; }
        public DateTime RespiteStartTime { get; set; }
        public DateTime RespiteFinishTime { get; set; }

        public List<ShiftDetailsVM> ShiftRespiteVMs { get; set; }
    }
}
