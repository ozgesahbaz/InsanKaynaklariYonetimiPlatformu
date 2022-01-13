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
        public bool isAproved { get; set; }

      
        public virtual int EmployeeId { get; set; }
        //public virtual Manager Manager { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual int ManagerId { get; set; }

    }
}
