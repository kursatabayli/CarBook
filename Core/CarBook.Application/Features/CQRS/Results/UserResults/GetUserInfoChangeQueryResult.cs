using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.UserResults
{
    public class GetUserInfoChangeQueryResult
    {
        public string OldPassword { get; set; }
    }
}
