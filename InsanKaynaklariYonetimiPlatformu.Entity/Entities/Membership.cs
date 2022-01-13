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
  public  class Membership
    {
        [Key]
        public  int MembershipId { get; set; }
        public MembershipType MembershipType { get; set; }
        [ForeignKey("Company")]
        public virtual int CompanyId { get; set; }

    }
}
