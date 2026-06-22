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

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty; // Stock Keeping Unit

        public decimal Price { get; set; }
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        public int StockQuantity { get; set; }
        public string[]? ImageUrls { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties - allow nulls for EF materialization
        public Brand? Brand { get; set; }

        // Fixed: keep numeric foreign key and add navigation property
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
