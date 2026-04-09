using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.DTOs.OrderDTOs
{
    public class CreateOrderItemDTO
    {
        public int ArticleID { get; set; }
        public int Quantity { get; set; }
    }
}
