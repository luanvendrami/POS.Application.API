using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
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
            channel.QueueDeclare(queue: "orders",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                JObject mensagem = JsonConvert.DeserializeObject<JObject>(json);
                Thread.Sleep(1000);

                Console.WriteLine("Order received: \n" + mensagem!.ToString(Newtonsoft.Json.Formatting.Indented));
            };
            channel.BasicConsume(queue: "orders",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine("Exit");
            Console.ReadLine();
        }
    }
}