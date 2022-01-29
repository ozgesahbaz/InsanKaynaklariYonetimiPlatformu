using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using System.Collections.Generic;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    internal interface IEmployeeServis
    {
        List<ExpenditureVM> GetListExpenditure(int id);
    }
}