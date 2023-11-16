using Domain.Enum;

namespace Domain.Dto.Request
{
    public class GrillOrderDto : OrderDto
    {
        public string OrderType { get; } = "Grill";
        public MeatType Meat { get; set; }
        public CookingLevel CookingPreference { get; set; }
        public bool SideDishes { get; set; } 
        public int Quantity { get; set; }
    }
}
