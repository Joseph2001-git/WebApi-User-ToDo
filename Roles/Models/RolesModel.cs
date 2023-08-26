using System.ComponentModel.DataAnnotations;

namespace Roles.Models
{
    public class RolesModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Role{ get; set; }

    }
}
