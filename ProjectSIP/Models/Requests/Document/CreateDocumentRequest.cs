using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectSIP.Models.Requests.Document
{
    public class CreateDocumentRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime SigntureDate { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public FromCreate From { get; set; }
        [Required]
        public ToCreate To { get; set; }

        // specific
        public string DocumentNumber { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
