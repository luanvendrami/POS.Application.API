using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Request
{
    public class SaladOrderDto : OrderDto
    {
        public string OrderType { get; } = "Salad";
        public SaladType Type { get; set; }
        public DressingType Dressing { get; set; }
        public bool HasProtein { get; set; } // Indica se o pedido inclui proteína (frango, camarão, etc.)
        public int Quantity { get; set; }
    }
}
