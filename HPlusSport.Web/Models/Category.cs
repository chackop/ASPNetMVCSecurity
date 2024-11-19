﻿using System.Collections.Generic;

namespace HPlusSport.Web.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}