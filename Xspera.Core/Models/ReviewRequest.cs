using System;
using System.Collections.Generic;
using System.Text;

namespace Xspera.Core.Models
{
    public class ReviewRequest
    {
        public int ProductId { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
