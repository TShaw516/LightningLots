using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLots.Models.ViewModel
{
    public class LotCreateViewModel
    {
        public string LotName { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public double Weight { get; set; }
        public IFormFile Attachment { get; set; }
        public virtual ICollection<Reagent> Reagents { get; set; }
    }
}
