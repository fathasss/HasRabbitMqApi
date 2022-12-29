using RabbitMQ.Client;

namespace HasRabbitMqApi.Controllers
{
    public class RabbitMqController
    {
        private readonly string _hostName = "localhost";

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory() { HostName = _hostName };

            return connectionFactory.CreateConnection();
        }
    }
}
