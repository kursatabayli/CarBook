using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticDtos
{
    public class ResultStatisticDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int BrandCount { get; set; }
        public decimal D_AvgCarR_Price { get; set; }
        public int  TestimonialsCount { get; set; }

    }
}
