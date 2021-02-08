using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public  class CarDTOs:IDTOs
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
    }
}
