using Data.Infra.Context;
using Data.Repository.Base;
using Domain.Entities;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Infra.Repository
{
    public class GrillOrderRepository : BaseRepository<GrillOrder>, IGrillOrderRepository
    {
        public GrillOrderRepository(DataContext context) : base(context) { }

        public async Task<List<GrillOrder>> GetGrillOrdersForId(int idOrder)
        {
            return await _context.GrillOrder.Where(e => e.IdOrder == idOrder).ToListAsync();
        }
    }
}
