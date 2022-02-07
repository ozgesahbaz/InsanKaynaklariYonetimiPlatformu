using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    class DeleteExpenditureVM
    {
        public int ID { get; set; }
        public int ExpenditureName{ get; set; }
        public decimal ExpenditureAmount { get; set; }
        public string Details { get; set; }
    }
}
