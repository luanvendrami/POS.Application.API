using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DrinkOrder : Order
    {
        public int Id { get; private set; }
        public DrinkType Type { get; private set; }
        public IceLevel IcePreference { get; private set; }
        public bool HasSugar { get; private set; } // Indica se o pedido inclui açúcar ou adoçante
        public bool HasLemon { get; private set; } // Indica se o pedido inclui limão
        public int Quantity { get; private set; }

        public DrinkOrder(int idOrder, string? specialInstructions, DrinkType type, IceLevel icePreference, bool hasSugar, bool hasLemon, int quantity) : base(idOrder, specialInstructions)
        {
            Type = type;
            IcePreference = icePreference;
            HasSugar = hasSugar;
            HasLemon = hasLemon;
            Quantity = quantity;
        }

        public DrinkOrder()
        {
        }
    }
}
