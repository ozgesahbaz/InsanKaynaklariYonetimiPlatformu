using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.BLL.Services.Concrete
{
  public  class ShiftService: IShiftService
    {
        IShiftRepository shiftRepository;
        public ShiftService(IShiftRepository _shiftRepository)
        {
            shiftRepository = _shiftRepository;
        }
    }
}
