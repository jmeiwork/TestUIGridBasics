using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class ForecastSheet
    {
        public Guid Id { get; set; }
        public int ForecastSheetTypeId { get; set; }
        public string Name { get; set; }

        public virtual ForecastSheetType ForecastSheetType { get; set; }
        public virtual ICollection<ForecastGrouping> ForecastGroupings { get; set; }
        public virtual ICollection<EntitlementDetail> EntitlementDetails { get; set; }
    }

    public class ForecastGrouping
    {
        public Guid Id { get; set; }
        public int GradeId { get; set; }
        public int PoolId { get; set; }
        public Guid ForecastSheetId { get; set; }
        public Guid NoteId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Pool Pool { get; set; }
        public virtual ForecastSheet ForecastSheet { get; set; }
        public virtual Note Note { get; set; }

        public int SortOrder { get; set; }
    }

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

    public class Note
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }

    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Lookup
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
    }

    public class ForecastSheetType : Lookup
    {
    }

    public class ForecastDetailType : Lookup
    {
    }

    public class Grade : Lookup
    {
    }

    public class Pool : Lookup
    {
    }

    public class EntitlementType : Lookup
    {
    }

    public enum ForecastSheetTypeEnum
    {
        WorkInProgress = 1,
        Forecast = 2,
        Confirmed = 3
    }

    public enum ForecastDetailTypeEnum
    {
        SupplyOpeningInventory = 1,
        SupplyProducer = 2,
        SupplyAdjustments = 3,
        TotalSupply = 4,
        TotalSales = 5,
        EndingInventory = 6,
        Target = 7
    }

    public enum EntitlementTypeEnum
    {
        StandardVariance = 1,
        PremiumVariance = 2,
        TotalVariance = 3
    }
}
