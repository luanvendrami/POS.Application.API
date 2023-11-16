using Domain.Dto.Request;

namespace Domain.Interface.Service
{
    public interface IDrinkOrderService
    {
        void SendDrinkOrder(DrinkOrderDto order);
    }
}
