using Domain.Enum;

namespace Domain.Entities
{
    public class SaladOrder : Order
    {
        public int Id { get; private set; }
        public SaladType Type { get; private set; }
        public DressingType Dressings { get; private set; }
        public bool HasProtein { get; private set; } // Indica se o pedido inclui proteína (frango, camarão, etc.)
        public int Quantity { get; private set; }

        public SaladOrder(int idOrder, string? specialInstructions, SaladType type, DressingType dressings, bool hasProtein, int quantity) : base(idOrder, specialInstructions)
        {
            Type = type;
            Dressings = dressings;
            HasProtein = hasProtein;
            Quantity = quantity;
        }

        public SaladOrder()
        {
            
        }
    }
}
