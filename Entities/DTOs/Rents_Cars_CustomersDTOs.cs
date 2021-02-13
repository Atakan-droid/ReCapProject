using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class Rents_Cars_CustomersDTOs:IDTOs
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public DateTime? RentDate { get; set; }
    }
}
