using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Concrete
{
    public class ShiftRepository: IShiftRepository
    {
        HRDataBaseContext dbContext;
        public ShiftRepository(HRDataBaseContext db)
        {
            dbContext = db;
        }
    }
}
