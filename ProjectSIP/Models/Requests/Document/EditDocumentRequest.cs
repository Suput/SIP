using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectSIP.Models.Requests.Document
{
    public class EditDocumentRequest
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SigntureDate { get; set; }
        public DateTime CreationDate { get; set; }
        public FromEdit From { get; set; }
        public ToEdit To { get; set; }

        // specific
        public string DocumentNumber { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
