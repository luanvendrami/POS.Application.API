using Data.Infra.Context;
using Domain.Dto.Request;
using Domain.Entities;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Microsoft.Extensions.Caching.Memory;

namespace Service
{
    public class DrinkOrderService : IDrinkOrderService
    {
        private readonly IRabbitMQRepository _repository;
        private readonly IDrinkOrderRepository _drinkOrderRepository;

        public DrinkOrderService(IRabbitMQRepository repository, IDrinkOrderRepository drinkOrderRepository)
        {
            _repository = repository;
            _drinkOrderRepository = drinkOrderRepository;
        }

        public void SendDrinkOrder(DrinkOrderDto order)
        {
            _repository.SendOrders(order, "drink-orders", "orders");

            CreateDrinkOrder(order);
        }

        public void CreateDrinkOrder(DrinkOrderDto order)
        {
            _drinkOrderRepository.Add(new DrinkOrder(order.IdOrder, order.SpecialInstructions!, order.Type, order.IcePreference, order.HasSugar, order.HasLemon, order.Quantity));
            _drinkOrderRepository.SaveChanges();    
        }     
    }
}
