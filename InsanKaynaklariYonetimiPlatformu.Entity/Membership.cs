using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity
{
  public  class Membership
    {
        public int MemberId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
