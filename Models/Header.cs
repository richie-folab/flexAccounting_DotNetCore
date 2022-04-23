using System;
using System.Collections.Generic;

namespace FlexAccounting.Models
{
    public partial class Header
    {
        public Header()
        {
            Entries = new HashSet<Entry>();
        }

        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string AccountingId { get; set; }
        public string Narration { get; set; }
        public string ChannelId { get; set; }
        public string CoreBankingRef { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Application Application { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
