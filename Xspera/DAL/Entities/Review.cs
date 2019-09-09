using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xspera.DAL.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("Review")]
        public virtual Product Product { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Review")]
        public virtual User User { get; set; }
    }
}
