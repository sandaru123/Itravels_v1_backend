using System;
using System.Collections.Generic;

namespace Itravels_v1.DAL
{
    public partial class Inquiry
    {
        public int InquiryId { get; set; }
        public int BaggageId { get; set; }
        public string Status { get; set; }
        public int? InquiryStatusId { get; set; }
        public int? InquiryReslutId { get; set; }

        public virtual Baggage Baggage { get; set; }
        public virtual InquiryResult InquiryReslut { get; set; }
        public virtual InquiryStatuses InquiryStatus { get; set; }
    }
}
