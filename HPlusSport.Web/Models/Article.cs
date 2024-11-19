using System.Collections.Generic;

namespace HPlusSport.Web.Models
{
    public class Article
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}