﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.LocationDtos
{
    public class UpdateLocationDto
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
		public string Maps { get; set; }
    }
}
