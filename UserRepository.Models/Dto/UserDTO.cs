namespace UserRegistration.Models.Dtos
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        
    }
}
