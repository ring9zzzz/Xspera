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

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
