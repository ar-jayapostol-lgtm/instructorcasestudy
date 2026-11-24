using System.ComponentModel.DataAnnotations;

namespace Instrutorcasestudy.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Major { get; set; } = string.Empty;

        public string BachelorDegree { get; set; } = string.Empty;

        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = string.Empty;
    }
}