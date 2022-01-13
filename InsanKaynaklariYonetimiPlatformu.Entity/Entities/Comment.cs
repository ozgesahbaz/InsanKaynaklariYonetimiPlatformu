using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.Entities
{
   public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Description { get; set; }
        [ForeignKey("Manager")]
        public virtual int ManagerId { get; set; }
        

    }
}
