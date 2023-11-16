using Domain.Entities;
using Domain.Interface.Repository.Base;

namespace Domain.Interface.Repository
{
    public interface IGrillOrderRepository : IBaseRepository<GrillOrder>
    {
        Task<List<GrillOrder>> GetGrillOrdersForId(int idOrder);
    }
}
