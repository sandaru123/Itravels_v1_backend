using System;
using System.Collections.Generic;

namespace Itravels_v1.DAL
{
    public partial class InquiryStatuses
    {
        public InquiryStatuses()
        {
            Inquiry = new HashSet<Inquiry>();
        }

        public int InquiryStatusId { get; set; }
        public string InquiryStatus { get; set; }

        public virtual ICollection<Inquiry> Inquiry { get; set; }
    }
}
