using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity
{
    public class Managers
    {
        public int ManagersId { get; set; }
        public string FullName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public StatusType StatusType { get; set; }
        public bool IsActive { get; set; }
    }
}
