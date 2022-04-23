using System;
using System.Collections.Generic;

namespace FlexAccounting.Models
{
    public partial class Application
    {
        public Application()
        {
            Headers = new HashSet<Header>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Header> Headers { get; set; }
    }
}
