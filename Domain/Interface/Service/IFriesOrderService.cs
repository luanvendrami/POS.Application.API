using Domain.Dto.Request;

namespace Domain.Interface.Service
{
    public interface IFriesOrderService
    {
        void SendFriesOrder(OrderFriesDto order);
    }
}
