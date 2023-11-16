using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Request
{
    public class OrderFriesDto : OrderDto
    {
        public string OrderType { get; } = "Fries";
        public FriesSize Size { get; set; }
        public SauceType Sauce { get; set; }
        public int Quantity { get; set; }
    }
}
