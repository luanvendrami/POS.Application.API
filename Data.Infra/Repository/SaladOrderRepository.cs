using Data.Infra.Context;
using Data.Repository.Base;
using Domain.Entities;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infra.Repository
{
    public class SaladOrderRepository : BaseRepository<SaladOrder>, ISaladOrderRepository
    {
        public SaladOrderRepository(DataContext context) : base(context) { }

        public async Task<List<SaladOrder>> GetSaladOrdersForId(int idOrder)
        {
            return await _context.SaladOrder.Where(e => e.IdOrder == idOrder).ToListAsync();
        }
    }
}
