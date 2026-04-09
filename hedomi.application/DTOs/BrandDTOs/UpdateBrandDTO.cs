using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedomi.application.DTOs.BrandDTOs
{
    public class UpdateBrandDTO
    {
        public string BrandName { get; set; }
        public string? LogoUrl { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
