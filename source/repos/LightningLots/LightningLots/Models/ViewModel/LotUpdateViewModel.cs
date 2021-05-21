using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLots.Models.ViewModel
{
    public class LotUpdateViewModel : LotCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingAttachmentPath { get; set; }
    }
}
