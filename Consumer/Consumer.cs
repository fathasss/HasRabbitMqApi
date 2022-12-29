using HasRabbitMqApi.Controllers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace HasRabbitMqApi.Consumer
{
    public class Consumer
    {
        private readonly RabbitMqController _rabbitMQService;

        public Consumer(string queueName)
        {
            _rabbitMQService = new RabbitMqController();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body.ToArray());

                        Console.WriteLine("{0} isimli queue üzerinden gelen mesaj: \"{1}\"", queueName, message);
                    };

                    channel.BasicConsume(queueName, true, consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}
