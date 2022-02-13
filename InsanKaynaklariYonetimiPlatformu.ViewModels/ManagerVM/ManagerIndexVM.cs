using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class ManagerIndexVM
    {
        public ManagerIndexVM()
        {
            employees = new List<Employee>();
            expenditures = new List<Expenditure>();
        }
        //public int id { get; set; /*}*/
        public List<Employee> employees { get; set; }
      
        public List<Expenditure> expenditures { get; set; }

    }
}
