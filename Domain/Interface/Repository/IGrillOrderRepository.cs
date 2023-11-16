using Domain.Entities;
using Domain.Interface.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IGrillOrderRepository : IBaseRepository<GrillOrder>
    {
        Task<List<GrillOrder>> GetGrillOrdersForId(int idOrder);
    }
}
