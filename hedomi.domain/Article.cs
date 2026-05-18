using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.domain
{
    public class Article
    {
        public int ArticleID { get; set; }
        public int BrandID { get; set; }

        public string Name { get; set; } 
        public string Description { get; set; }
        public string SKU { get; set; } // Stock Keeping Unit

        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

    

        public int StockQuantity { get; set; }
        public string[] ImageUrls { get; set; } 

        public bool IsActive { get; set; }

        public Brand Brand { get; set; }

        public Category Category { get; set; }
    }
}
