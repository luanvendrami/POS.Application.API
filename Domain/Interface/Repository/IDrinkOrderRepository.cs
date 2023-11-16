using Domain.Entities;
using Domain.Interface.Repository.Base;

namespace Domain.Interface.Repository
{
    public interface IDrinkOrderRepository : IBaseRepository<DrinkOrder>
    {
        Task<List<DrinkOrder>> GetDrinkOrdersForId(int idOrder);
    }
}
