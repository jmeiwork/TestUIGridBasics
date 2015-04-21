using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestUIGridBasics.Controllers
{
    public class SearchResultsController : ApiController
    {
        private SearchResult[] SearchResults =
        {
            new SearchResult
            {
                PoolCategory = "Standard",
                Grade = "RSTD",
                Notes = "This is a note.",
                ResultType = ResultTypeEnum.SupplyHeader.ToString(),
                Amounts =
                    new ResultRowAmounts()
                    {
                        Label = "Supply: O/I",
                        Jan = 21,
                        Feb = 32,
                        Mar = 43,
                        Apr = 0,
                        May = 0,
                        Jun = 0,
                        Jul = 0,
                        Aug = 0,
                        Sep = 0,
                        Oct = 0,
                        Nov = 0,
                        Dec = 0
                    }
            },
            new SearchResult
            {
                PoolCategory = "Standard",
                Grade = "RSTD",
                Notes = "This is a note.",
                ResultType = ResultTypeEnum.SupplyDetail.ToString(),
                Amounts =
                    new ResultRowAmounts()
                    {
                        Label = "Supply: Agrium",
                        Jan = 0,
                        Feb = 34,
                        Mar = 25,
                        Apr = 90,
                        May = 8,
                        Jun = 70,
                        Jul = 60,
                        Aug = 50,
                        Sep = 40,
                        Oct = 30,
                        Nov = 20,
                        Dec = 0
                    }
            },
            new SearchResult
            {
                PoolCategory = "Standard",
                Grade = "RSTD",
                Notes = "This is a note.",
                ResultType = ResultTypeEnum.AdjustmentHeader.ToString(),
                Amounts =
                    new ResultRowAmounts()
                    {
                        Label = "Adjustments",
                        Jan = 30,
                        Feb = 94,
                        Mar = 95,
                        Apr = 90,
                        May = 9,
                        Jun = 90,
                        Jul = 90,
                        Aug = 90,
                        Sep = 90,
                        Oct = 90,
                        Nov = 90,
                        Dec = 1
                    }
            },
            new SearchResult
            {
                PoolCategory = "Standard",
                Grade = "RSTD",
                Notes = "This is a note.",
                ResultType = ResultTypeEnum.Total.ToString(),
                Amounts =
                    new ResultRowAmounts()
                    {
                        Label = "TOTAL SUPPLY",
                        Jan = 530,
                        Feb = 5334,
                        Mar = 5325,
                        Apr = 5390,
                        May = 538,
                        Jun = 5370,
                        Jul = 5360,
                        Aug = 5350,
                        Sep = 5340,
                        Oct = 5330,
                        Nov = 5320,
                        Dec = 530
                    }
            },
            new SearchResult
            {
                PoolCategory = "Standard",
                Grade = "RSTD",
                Notes = "This is a note.",
                ResultType = ResultTypeEnum.EndingInventory.ToString(),
                Amounts =
                    new ResultRowAmounts()
                    {
                        Label = "ENDING INVENTORY",
                        Jan = 770,
                        Feb = 7734,
                        Mar = 7725,
                        Apr = 7790,
                        May = 778,
                        Jun = 7770,
                        Jul = 7760,
                        Aug = 7750,
                        Sep = 7740,
                        Oct = 7730,
                        Nov = 7720,
                        Dec = 770
                    }
            },
            new SearchResult
            {
                PoolCategory = "Standard",
                Grade = "RSTD",
                Notes = "This is a note.",
                ResultType = ResultTypeEnum.Target.ToString(),
                Amounts =
                    new ResultRowAmounts()
                    {
                        Label = "TARGET",
                        Jan = 12450,
                        Feb = 124534,
                        Mar = 124525,
                        Apr = 124590,
                        May = 12458,
                        Jun = 124570,
                        Jul = 124560,
                        Aug = 124550,
                        Sep = 124540,
                        Oct = 124530,
                        Nov = 124520,
                        Dec = 12450
                    }
            }
        };
                       
        

        public IEnumerable<SearchResult> GetAllSearchResults()
        {
            return SearchResults;
        }

        public IHttpActionResult GetSearchResult(int id)
        {
            //var Widget = Widgets.FirstOrDefault((p) => p.Id == id);
            //if (Widget == null)
            //{
            //    return NotFound();
            //}
            //return Ok(Widget);
            return null;
        }
    }

    public class SearchResult
    {
        public string PoolCategory { get; set; }
        public string Grade { get; set; }
        public string Notes { get; set; }
        public string ResultType { get; set; }
        public ResultRowAmounts Amounts { get; set; }
    }

    public enum ResultTypeEnum
    {
        SupplyHeader,
        SupplyDetail,
        AdjustmentHeader,
        Total,
        EndingInventory,
        Target
    }

    public class ResultRowAmounts
    {
        public string Label { get; set; }
        public decimal Jan { get; set; }
        public decimal Feb { get; set; }
        public decimal Mar { get; set; }
        public decimal Apr { get; set; }
        public decimal May { get; set; }
        public decimal Jun { get; set; }
        public decimal Jul { get; set; }
        public decimal Aug { get; set; }
        public decimal Sep { get; set; }
        public decimal Oct { get; set; }
        public decimal Nov { get; set; }
        public decimal Dec { get; set; }

    }

}
