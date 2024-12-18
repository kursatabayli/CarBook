﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CommentResults
{
    public class GetCommentQueryResult
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogID { get; set; }
        public bool IsActive { get; set; }
    }
}
