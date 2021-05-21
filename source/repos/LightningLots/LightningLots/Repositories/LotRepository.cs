using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightningLots.Models.ViewModel;

namespace LightningLots.Repositories
{
    public class LotsRepository : Repository<Lot>
    {
        public LotsRepository(LightningLotsContext context) : base(context)
        {

        }
    }
}
