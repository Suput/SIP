using System;

namespace ProjectSIP.Models.Document
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SigntureDate { get; set; }
        public DateTime CreationDate { get; set; }

        public int FromId { get; set; }
        public From From { get; set; }

        public int ToId { get; set; }
        public To To { get; set; }

        // specific
        public string DocumentNumber { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
