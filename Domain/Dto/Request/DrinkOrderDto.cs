using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Request
{
    public class DrinkOrderDto : OrderDto
    {
        public string OrderType { get; } = "Drink";
        public DrinkType Type { get; set; }
        public IceLevel IcePreference { get; set; }
        public bool HasSugar { get; set; } // Indica se o pedido inclui açúcar ou adoçante
        public bool HasLemon { get; set; } // Indica se o pedido inclui limão
        public int Quantity { get; set; }
    }
}
