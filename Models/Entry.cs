using System;
using System.Collections.Generic;

namespace FlexAccounting.Models
{
    public partial class Entry
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string AccountingId { get; set; }
        public string AcctNo { get; set; }
        public string TranCode { get; set; }
        public string DrCr { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Narration { get; set; }
        public string IncludeIf { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Remark { get; set; }

        public virtual Header Header { get; set; }
        public virtual TranCode TranCodeNavigation { get; set; }
    }
}
