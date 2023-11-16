using Domain.Entities;
using Domain.Interface.Repository.Base;

namespace Domain.Interface.Repository
{
    public interface IFriesOrderRepository : IBaseRepository<FriesOrder>
    {
        Task<List<FriesOrder>> GetFriesOrdersForId(int idOrder);
    }
}
