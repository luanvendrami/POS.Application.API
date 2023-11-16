using Domain.Dto.Response;

namespace Domain.Interface.Service
{
    public interface IOrderService
    {
        Task<OrderDataReponseDto> GetOrdersForId(int idOrder);
    }
}
