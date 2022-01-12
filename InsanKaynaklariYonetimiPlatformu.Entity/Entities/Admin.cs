using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
    class Admin
    {
        public int AdminId { get; set; }
        public string FullName { get; set; }
        public int ManagerId { get; set; }
    }
}
