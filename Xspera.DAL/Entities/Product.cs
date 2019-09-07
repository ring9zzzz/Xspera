using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xspera.DAL.Entities
{
    public partial class Product
    {
        public Product()
        {
            Review = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        public int AvailableStatus { get; set; }
        public int? CreatedBy { get; set; }

        [ForeignKey("BrandId")]
        [InverseProperty("Product")]
        public virtual Brand Brand { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<Review> Review { get; set; }
    }
}
