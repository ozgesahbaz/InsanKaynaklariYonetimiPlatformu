using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity
{
   public class Permission
    {
        public int PermissionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public PermissionType PermissionType { get; set; }
        public int ManagerId { get; set; }
        public int? PersonelId { get; set; }


    }
}
