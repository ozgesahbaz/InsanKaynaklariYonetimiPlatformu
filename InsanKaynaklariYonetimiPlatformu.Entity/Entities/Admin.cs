using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
   public class Admin
    {
        public Admin()
        {
            Managers = new HashSet<Manager>();
        }
       
        public int AdminId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }


    }
}

