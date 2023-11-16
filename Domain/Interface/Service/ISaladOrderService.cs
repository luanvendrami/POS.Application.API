using Domain.Dto.Request;

namespace Domain.Interface.Service
{
    public interface ISaladOrderService
    {
        void SendSaladOrder(SaladOrderDto order);
    }
}
