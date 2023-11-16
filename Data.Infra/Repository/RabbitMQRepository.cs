using Domain.Interface.Repository;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Data.Infra.Repository
{
    public class RabbitMQRepository : IRabbitMQRepository
    {
        public void SendOrders<T>(T value, string queue, string routingKey)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string json = JsonSerializer.Serialize(value);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
