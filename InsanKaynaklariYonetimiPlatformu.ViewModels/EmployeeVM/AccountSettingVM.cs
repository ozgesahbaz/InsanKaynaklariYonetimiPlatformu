using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM
{
    public class AccountSettingVM
    {
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
