using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xspera.DAL.Entities
{
    public partial class User
    {
        public User()
        {
            Review = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int Type { get; set; }
        [Required]
        [StringLength(25)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfBirth { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Review> Review { get; set; }
    }
}
