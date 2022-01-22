using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
   public class Respite
    {
        public int RespiteID { get; set; }
       
        public DateTime RespiteStartTime { get; set; }
        public DateTime RespiteFinishTime { get; set; }
        public int? ShiftId { get; set; }
    
        public  virtual Shift Shift { get; set; }
    }
}
