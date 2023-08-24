using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace UserRegistration.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string? Password { get; set; }
        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string? CheckPassword { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }

        

    }
}
