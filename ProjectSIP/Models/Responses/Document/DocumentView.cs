using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSIP.Models.Responses.Document
{
    public class DocumentView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SigntureDate { get; set; }
        public DateTime CreationDate { get; set; }
        public FromView From { get; set; }
        public ToView To { get; set; }

        // specific
        public string DocumentNumber { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
