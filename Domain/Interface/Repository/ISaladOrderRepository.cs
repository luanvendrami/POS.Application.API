using Domain.Entities;
using Domain.Interface.Repository.Base;

namespace Domain.Interface.Repository
{
    public interface ISaladOrderRepository : IBaseRepository<SaladOrder>
    {
        Task<List<SaladOrder>> GetSaladOrdersForId(int idOrder);
    }
}
