using Data.Infra.Context;
using Data.Repository.Base;
using Domain.Entities;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Infra.Repository
{

    public class DrinkOrderRepository : BaseRepository<DrinkOrder>, IDrinkOrderRepository
    {
        public DrinkOrderRepository(DataContext context) : base(context) { }

        public async Task<List<DrinkOrder>> GetDrinkOrdersForId(int idOrder)
        {
            return await _context.DrinkOrder.Where(e => e.IdOrder == idOrder).ToListAsync();
        }
    }
}
