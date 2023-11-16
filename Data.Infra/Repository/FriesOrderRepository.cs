using Data.Infra.Context;
using Data.Repository.Base;
using Domain.Entities;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Infra.Repository
{
    public class FriesOrderRepository : BaseRepository<FriesOrder>, IFriesOrderRepository
    {
        public FriesOrderRepository(DataContext context) : base(context) { }

        public async Task<List<FriesOrder>> GetFriesOrdersForId(int idOrder)
        {
            return await _context.FriesOrder.Where(e => e.IdOrder == idOrder).ToListAsync();
        }
    }
}
