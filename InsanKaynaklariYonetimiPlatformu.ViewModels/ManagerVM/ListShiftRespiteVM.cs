using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class ListShiftRespiteVM
    {
        public ListShiftRespiteVM()
        {
            ListofShifts = new List<Shift>();
            ListofRespite= new List<Respite>();
        }
        public List<Shift> ListofShifts { get; set; }
        public List<Respite> ListofRespite { get; set; }

    }
}
