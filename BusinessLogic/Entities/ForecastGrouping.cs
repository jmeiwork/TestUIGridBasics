using System;

namespace BusinessLogic.Entities
{
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
}