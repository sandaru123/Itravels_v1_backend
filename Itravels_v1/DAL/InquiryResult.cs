using System;
using System.Collections.Generic;

namespace Itravels_v1.DAL
{
    public partial class InquiryResult
    {
        public InquiryResult()
        {
            Inquiry = new HashSet<Inquiry>();
        }

        public int InquiryResultId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Inquiry> Inquiry { get; set; }
    }
}
