using Data.Infra.Context;
using Domain.Dto.Request;
using Domain.Entities;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GrillOrderService : IGrillOrderService
    {
        private readonly IRabbitMQRepository _repository;
        private readonly IGrillOrderRepository _grillOrderRepository;

        public GrillOrderService(IRabbitMQRepository repository, IGrillOrderRepository grillOrderRepository)
        {
            _repository = repository;
            _grillOrderRepository = grillOrderRepository;
        }

        public void SendGrillOrder(GrillOrderDto order)
        {
            _repository.SendOrders(order, "grill-orders", "orders");

            CreateGrillOrder(order);
        }

        public void CreateGrillOrder(GrillOrderDto order)
        {
            _grillOrderRepository.Add(new GrillOrder(order.IdOrder, order.SpecialInstructions!, order.Meat, order.CookingPreference, order.SideDishes, order.Quantity));
            _grillOrderRepository.SaveChanges();
        }
    }
}
