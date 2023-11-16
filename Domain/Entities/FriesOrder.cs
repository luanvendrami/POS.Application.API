using Domain.Enum;

namespace Domain.Entities
{
    public class FriesOrder : Order
    {
        public int Id { get; private set; }
        public FriesSize Size { get; private set; }
        public SauceType Sauces { get; private set; }
        public int Quantity { get; private set; }

        public FriesOrder(int idOrder, string? specialInstructions, FriesSize size, SauceType sauces, int quantity) : base(idOrder, specialInstructions)
        {
            Size = size;
            Sauces = sauces;
            Quantity = quantity;
        }

        public FriesOrder()
        {
        }
    }
}
