using System.ComponentModel.DataAnnotations;

namespace Instrutorcasestudy.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AdminID { get; set; } = string.Empty;

        public int Age { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}