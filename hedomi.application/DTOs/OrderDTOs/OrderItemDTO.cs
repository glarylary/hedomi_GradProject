using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.DTOs.OrderDTOs
{
    public class OrderItemDTO
    {
        public int ArticleID { get; set; }
        public string ArticleName { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }
    }
}
