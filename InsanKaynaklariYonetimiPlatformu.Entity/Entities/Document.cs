using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
    public class Document
    {
        public int DocumentID { get; set; }
        public string DocumentPath { get; set; }

        public string DocumentName { get; set; }

        public int? EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
