using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Concrete
{
   public class RespiteRepository:IRespiteRepository
    {
        HRDataBaseContext dbContext;
        public RespiteRepository(HRDataBaseContext _dbContext)
        {
            dbContext = _dbContext;
        }
    }
}
