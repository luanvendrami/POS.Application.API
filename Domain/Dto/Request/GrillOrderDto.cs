using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Request
{
    public class GrillOrderDto : OrderDto
    {
        public string OrderType { get; } = "Grill";
        public MeatType Meat { get; set; }
        public CookingLevel CookingPreference { get; set; }
        public bool SideDishes { get; set; } // Indica se o pedido inclui acompanhamentos
        public int Quantity { get; set; }
    }
}
