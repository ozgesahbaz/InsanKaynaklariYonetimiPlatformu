using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
   public class Permission
    {
       
        public int PermissionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public PermissionType PermissionType { get; set; }

      // Her Permission bir employee ait olacak. Null geçilebilir çakışma olmaması için
        public  int? EmployeeId { get; set; }     
        public  Employee Employee { get; set; }

        // Her Permission bir manager ait olacak. Null geçilebilir çakışma olmaması için
        public int? ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
