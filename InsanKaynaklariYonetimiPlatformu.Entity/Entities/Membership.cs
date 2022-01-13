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
       
        public  int MembershipId { get; set; }
        public MembershipType MembershipType { get; set; }
        
        //Her company'nin bir üyeliği olacak
        public  int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
