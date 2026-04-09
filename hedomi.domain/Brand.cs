using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.domain
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Slug { get; set; } 
        public string LogoUrl { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }


        public ICollection<Article> Articles { get; set; }
    }
}
