using System.ComponentModel.DataAnnotations;

namespace GemBoxDemo.Models
{
    public enum MailMergeDocType
    {
        PDF = 1,
        DOCX = 2
    }

    public class MailMergeModel
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Date Time")]
        [DataType(DataType.DateTime)]
        public DateTime? DocDateTime { get; set; } = DateTime.Now;

        [Display(Name = "Upload Template")]
        public IFormFile? TemplateFile { get; set; }

        [Display(Name = "Upload Image")]
        public IFormFile? ImageFile { get; set; }

        public byte[]? ImageBytes { get; set; }

        [Display(Name = "Doc Type")]
        public MailMergeDocType MailMergeDocType { get; set; } = MailMergeDocType.PDF;
    }
}
