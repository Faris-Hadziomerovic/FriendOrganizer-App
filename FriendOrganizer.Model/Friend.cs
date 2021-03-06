//using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace FriendOrganizer.Model
{
    public class Friend
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
