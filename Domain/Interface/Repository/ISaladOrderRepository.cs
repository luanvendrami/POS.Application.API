using Domain.Entities;
using Domain.Interface.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface ISaladOrderRepository : IBaseRepository<SaladOrder>
    {
        Task<List<SaladOrder>> GetSaladOrdersForId(int idOrder);
    }
}
