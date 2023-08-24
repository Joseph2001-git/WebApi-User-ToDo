using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserRegistration.Models;

namespace ToDoList.Models
{
    public class ToDoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? ToDoMessage { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
