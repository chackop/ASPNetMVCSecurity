using System.Collections.Generic;

namespace HPlusSport.Web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Salt { get; set; }
        public string Hash { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}