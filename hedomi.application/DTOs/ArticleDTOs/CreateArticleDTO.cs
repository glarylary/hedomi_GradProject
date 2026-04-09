using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.DTOs.ArticleDTOs
{
    public class CreateArticleDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int SKU { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
    }
}
