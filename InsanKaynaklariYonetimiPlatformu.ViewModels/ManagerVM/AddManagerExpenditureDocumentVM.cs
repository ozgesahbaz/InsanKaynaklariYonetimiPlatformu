using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class AddManagerExpenditureDocumentVM
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Dosya Seçiniz.", Description = "Lütfen sadece pdf dosyası seçiniz.")]
        public IFormFile File { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Dosya Adı Giriniz.")]
        public string FileName { get; set; }
    }
}
