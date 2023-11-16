using Domain.Dto.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Service
{
    public interface IOrderService
    {
        Task<OrderDataReponseDto> GetOrdersForId(int idOrder);
    }
}
