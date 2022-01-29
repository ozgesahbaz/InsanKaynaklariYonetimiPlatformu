using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class ShiftDetailsVM
    {
        public ShiftDetailsVM()
        {
            Employees=new List<Employee>();
        }
        public int RespiteID { get; set; }
        public int ShiftID { get; set; }
        public int ManagerID { get; set; }
        public int EmployeeID { get; set; }
        public List<Employee> Employees { get; set; }
        public string EmployeeFullName { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftFinishTime { get; set; }
        public DateTime RespiteStartTime { get; set; }
        public DateTime RespiteFinishTime { get; set; }


    }
}