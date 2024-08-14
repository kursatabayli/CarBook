using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.TagCloudDtos
{
    public class ResultGetTagCloudByIdDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BlogID { get; set; }
    }
}
