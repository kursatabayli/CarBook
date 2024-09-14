using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.StatisticResults
{
    public class GetHighestCarBrandQueryResult
    {
        public string HighestBrandName { get; set; }
        public int HighestBrandCount { get; set; }
    }
}
