using CORE.Entities;
using Entities.Concrete;
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
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Images { get; set; }

    }
}
