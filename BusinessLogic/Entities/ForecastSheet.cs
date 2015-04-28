using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class ForecastSheet
    {
        public int Id { get; set; }
        public int ForecastSheetTypeId { get; set; }
        public string Name { get; set; }
        public virtual ForecastSheetType ForecastSheetType { get; set; }
        public virtual ICollection<ForecastDetail> Details { get; set; }
        public virtual ICollection<EntitlementDetail> EntitlementDetails { get; set; }

    }

    public class EntitlementDetail
    {

    }

    public enum ForecastSheetTypeEnum
    {
        WorkInProgress = 1,
        Forecast = 2,
        Confirmed = 3
    }


    public class ForecastGrouping
    {
        public int Id { get; set; }
        public int GradeId { get; set; }
        public int PoolId { get; set; }
        public int ForecastSheetId { get; set; }
        public int NoteId { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Pool Pool { get; set; }
        public virtual ForecastSheet ForecastSheet { get; set; }
        public virtual Note Note { get; set; }
        public int SortOrder { get; set; }
    }

    public class ForecastDetail
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int ForecastDetailTypeId { get; set; }
        public int ForecastGroupingId { get; set; }
        public int ProducerId { get; set; }
        public virtual ForecastDetailType ForecastDetailType { get; set; }
        public virtual ForecastGrouping ForecastGrouping { get; set; }
        public virtual Producer Producer { get; set; }
        public decimal Amount { get; set; }
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


    public class Note
    {
        public int Id { get; set; }
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
}
