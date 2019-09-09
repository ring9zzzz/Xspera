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
     
        public string Name { get; set; }
        public decimal Price { get; set; }
      
        public string Color { get; set; }
        public string Description { get; set; } 
        public DateTime DateCreated { get; set; }
        public int AvailableStatus { get; set; }
        public int? CreatedBy { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
