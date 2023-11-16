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
    public class FriesOrderService : IFriesOrderService
    {
        private readonly IRabbitMQRepository _repository;
        private readonly IFriesOrderRepository _friesOrderRepository;

        public FriesOrderService(IRabbitMQRepository repository, IFriesOrderRepository friesOrderRepository)
        {
            _repository = repository;
            _friesOrderRepository = friesOrderRepository;
        }

        public void SendFriesOrder(OrderFriesDto order)
        {
            _repository.SendOrders(order, "fries-orders", "orders");

            CreateFriesOrder(order);
        }

        public void CreateFriesOrder(OrderFriesDto order)
        {
            _friesOrderRepository.Add(new FriesOrder(order.IdOrder, order.SpecialInstructions!, order.Size, order.Sauce, order.Quantity));
            _friesOrderRepository.SaveChanges();
        }
    }
}
