using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLots.Models.ViewModel
{
    public class Lot
    {
        public string LotName { get; set; }
        public int Id { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public double Weight { get; set; }
        public virtual ICollection<Reagent> Reagents { get; set; }

        public Lot()
        {

        }

        public Lot(string lotName, int id, DateTime creationTimeStamp, double weight)
        {
            LotName = lotName;
            Id = id;
            CreationTimeStamp = creationTimeStamp;
            Weight = weight;
        }

    }
}

