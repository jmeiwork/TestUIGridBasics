using System;

namespace BusinessLogic.Entities
{
    public class EntitlementDetail
    {
        public Guid Id { get; set; }
        public int ProducerId { get; set; }
        public int EntitlementTypeId { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual EntitlementType EntitlementType { get; set; }

        public int Month { get; set; }
        public decimal Amount { get; set; }
    }
}