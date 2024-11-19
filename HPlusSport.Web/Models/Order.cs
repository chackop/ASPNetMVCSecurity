using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HPlusSport.Web.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DisplayName("Order Date")] public DateTime OrderDate { get; set; }

        public virtual User User { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}