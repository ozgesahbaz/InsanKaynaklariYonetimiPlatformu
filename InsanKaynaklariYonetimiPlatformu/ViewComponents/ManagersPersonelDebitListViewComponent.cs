using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class ManagersPersonelDebitListViewComponent: ViewComponent 
    {
        //Burası manager controller olarak görev yapmaktadır. Geri kalan ilişkiler aynı şekilde devam eder. manager servis => manager repository
        IManagerService managerService;
        public ManagersPersonelDebitListViewComponent (IManagerService _managerService) 
        {
            managerService = _managerService;
        
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                //Burada Manager Servise gönderiyoruz debitleri listelemesi için.
                List<ManagersDebitVM> debitVMs = managerService.GetListManagersDebit(id);
                //Fakat listeleyebilmesi için öncelikle kayıtlı bir debit var mı onun kontrolünü sağlamalıyız.
                if (debitVMs != null)
                {
                    //Eğer kayıtlı debit bulunuyorsa debitVMs içerisindeki izin verdiğimiz propertler ışığında bize debitleri listeleyecek.
                    return View(debitVMs);
                }
                else
                {
                    throw new Exception("Henüz zimmet kaydınız bulunmamaktadır.");
                }
            }
            catch (Exception ex)
            {
                //Eğer hataya düşerse hata mesajını fırlt
                ModelState.AddModelError("exception", ex.Message);
            }
            //Hataya düşmesi durumunda sayfaya tekrar gelip hata mesajını gösterir
            return View();
        
        }

    }
    
}
