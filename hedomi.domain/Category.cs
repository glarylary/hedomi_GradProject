using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; } 
        public string Slug { get; set; }
        public int? Description { get; set; } 

        public ICollection<Article> Articles { get; set; }
    }
}
