using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class CompanySettingsVM
    {
        public IFormFile CompanyLogo { get; set; }
        public string LogoPath { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
    }
}
