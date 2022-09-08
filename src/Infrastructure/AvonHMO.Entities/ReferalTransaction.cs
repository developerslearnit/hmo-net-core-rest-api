using System;

namespace AvonHMO.Entities
{
    public partial class ReferalTransaction
    {
        public Guid ReferalTransactionId { get; set; }

        public string ReferalCode { get; set; }

        public int? MemberNo { get; set; }

        public Guid EnrolleeReferalId { get; set; }

        public Guid EnrolleeIviteeId { get; set; }

        public string PlanCode { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public bool Status { get; set; }
    }
}
