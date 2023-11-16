using Domain.Dto.Request;
using Domain.Entities;
using Domain.Interface.Repository;
using Domain.Interface.Service;

namespace Service
{
    public class SaladOrderService : ISaladOrderService
    {
        private readonly IRabbitMQRepository _repository;
        private readonly ISaladOrderRepository _saladOrderRepository;

        public SaladOrderService(IRabbitMQRepository repository, ISaladOrderRepository saladOrderRepository)
        {
            _repository = repository;
            _saladOrderRepository = saladOrderRepository;
        }

        public void SendSaladOrder(SaladOrderDto order)
        {
            _repository.SendOrders(order, "salad-orders", "orders");

            CreateSaladOrder(order);
        }

        public void CreateSaladOrder(SaladOrderDto order)
        {
            _saladOrderRepository.Add(new SaladOrder(order.IdOrder, order.SpecialInstructions!, order.Type, order.Dressing, order.HasProtein, order.Quantity));
            _saladOrderRepository.SaveChanges();
        }
    }
}
