using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.DTOs.CatagoryDTO
{
    public class UpdateCatagoryDTO
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? Description { get; set; }
    }
}
