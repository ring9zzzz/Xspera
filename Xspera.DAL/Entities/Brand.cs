using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xspera.DAL.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }

        [InverseProperty("Brand")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
