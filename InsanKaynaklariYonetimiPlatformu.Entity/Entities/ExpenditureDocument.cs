using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
   public class ExpenditureDocument
    {
        public int DocumentID { get; set; }
        public string DocumentPath { get; set; }

        public string DocumentName { get; set; }

        public int? ExpenditureId { get; set; }

        public virtual Expenditure Expenditure { get; set; }

    }
}
