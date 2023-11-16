using Domain.Enum;

namespace Domain.Dto.Request
{
    public class SaladOrderDto : OrderDto
    {
        public string OrderType { get; } = "Salad";
        public SaladType Type { get; set; }
        public DressingType Dressing { get; set; }
        public bool HasProtein { get; set; } 
        public int Quantity { get; set; }
    }
}
