using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLots.Models.ViewModel
{
    public class Reagent
    {
            public int Id { get; set; }
            public DateTime ReceiptTimeStamp { get; set; }
            public double Weight { get; set; }
            public bool IsQuarantineComplete { get; set; }
            public string Name { get; set; }

            public virtual Lot Lot { get; set; }
            public virtual int LotId { get; set; }

            public Reagent()
            {

            }

            public Reagent(int id, DateTime receiptTimeStamp, double weight, bool isQuarantineComplete, string name, int lotId)
            {
                Id = id;
                ReceiptTimeStamp = receiptTimeStamp;
                Weight = weight;
                IsQuarantineComplete = false;
                Name = name;
                LotId = lotId;

            }
     }
}
