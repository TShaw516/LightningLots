using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightningLots.Models.ViewModel;

namespace LightningLots.Repositories
{
    public class ReagentRepository : Repository<Reagent>
    {
        public ReagentRepository(LightningLotsContext context) : base(context)
        {

        }
    }
}
