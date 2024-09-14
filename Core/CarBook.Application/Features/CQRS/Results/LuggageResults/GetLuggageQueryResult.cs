using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.LuggageResults
{
    public class GetLuggageQueryResult
    {
        public int CarLuggageID { get; set; }
        public string LuggageType { get; set; }
    }
}
