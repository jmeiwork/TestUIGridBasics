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
}
