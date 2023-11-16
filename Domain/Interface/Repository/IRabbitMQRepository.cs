namespace Domain.Interface.Repository
{
    public interface IRabbitMQRepository
    {
        void SendOrders<T>(T value, string queue, string routingKey);
    }
}
