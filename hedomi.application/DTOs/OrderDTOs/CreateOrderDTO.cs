using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.DTOs.OrderDTOs
{
    public class CreateOrderDTO
    {
        public string UserID { get; set; }
        public List<CreateOrderItemDTO> Items { get; set; }
    }
}
