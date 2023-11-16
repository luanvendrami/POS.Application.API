using Domain.Dto.Request;

namespace Domain.Interface.Service
{
    public interface IGrillOrderService
    {
        void SendGrillOrder(GrillOrderDto order);
    }
}
