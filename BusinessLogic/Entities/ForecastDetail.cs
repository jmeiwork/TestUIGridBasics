using System;

namespace BusinessLogic.Entities
{
    public class ForecastDetail
    {
        public Guid Id { get; set; }
        public int ForecastDetailTypeId { get; set; }
        public Guid ForecastGroupingId { get; set; }
        public int ProducerId { get; set; }
        public virtual ForecastDetailType ForecastDetailType { get; set; }
        public virtual ForecastGrouping ForecastGrouping { get; set; }
        public virtual Producer Producer { get; set; }

        public int Month { get; set; }
        public decimal Amount { get; set; }
    }
}