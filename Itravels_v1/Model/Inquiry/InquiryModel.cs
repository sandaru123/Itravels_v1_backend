using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Model.Inquiry
{
    public class InquiryModel
    {
        public int BaggageId { get; set; }
        public string Status { get; set; }
        public int? InquiryStatusId { get; set; }
        public int? InquiryReslutId { get; set; }
    }

    public class InquiryUpdateModel
    {
        public int InquiryId { get; set; }
        public int BaggageId { get; set; }
        public string Status { get; set; }
        public int? InquiryStatusId { get; set; }
        public int? InquiryReslutId { get; set; }
    }
}
