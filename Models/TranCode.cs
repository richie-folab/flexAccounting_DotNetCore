using System;
using System.Collections.Generic;

namespace FlexAccounting.Models
{
    public partial class TranCode
    {
        public TranCode()
        {
            Entries = new HashSet<Entry>();
        }

        public string TranCode1 { get; set; }
        public string CoreBankingTc { get; set; }
        public string CoreBankingRvslTc { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
