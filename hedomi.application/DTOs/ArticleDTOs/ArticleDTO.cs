using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.DTOs.ArticleDTOs
{
    public class ArticleDTO
    {
        public int ArticleID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string SKU { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public string StockQuantity { get; set; }
    }
}
