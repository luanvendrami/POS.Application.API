using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GrillOrder : Order
    {
        public int Id { get; private set; }
        public MeatType Meat { get; private set; }
        public CookingLevel CookingPreference { get; private set; }
        public bool SideDishes { get; private set; } // Indica se o pedido inclui acompanhamentos
        public int Quantity { get; private set; }

        public GrillOrder(int idOrder, string? specialInstructions, MeatType meat, CookingLevel cookingPreference, bool sideDishes, int quantity) : base(idOrder, specialInstructions)
        {
            Meat = meat;
            CookingPreference = cookingPreference;
            SideDishes = sideDishes;
            Quantity = quantity;
        }

        public GrillOrder()
        {
        }
    }
}
