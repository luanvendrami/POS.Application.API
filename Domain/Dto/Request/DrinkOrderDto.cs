using Domain.Enum;

namespace Domain.Dto.Request
{
    public class DrinkOrderDto : OrderDto
    {
        public string OrderType { get; } = "Drink";
        public DrinkType Type { get; set; }
        public IceLevel IcePreference { get; set; }
        public bool HasSugar { get; set; } 
        public bool HasLemon { get; set; } 
        public int Quantity { get; set; }
    }
}
