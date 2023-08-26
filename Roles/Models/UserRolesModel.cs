using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserRegistration.Models;

namespace Roles.Models
{
    public class UserRolesModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public RolesModel Roles { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
