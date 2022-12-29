using System;

namespace HasRabbitMqApi
{
    public class RunMq
    {
        private static readonly string _queueName = "HasRabbitApiRequest";
        private static HasRabbitMqApi.Publisher.Publisher _publisher;
        private static HasRabbitMqApi.Consumer.Consumer _consumer;

        public static void ExecuteRabbitMq(string mqMessage)
        {
            _publisher = new HasRabbitMqApi.Publisher.Publisher(_queueName, mqMessage);
            _consumer = new HasRabbitMqApi.Consumer.Consumer(_queueName);

            Console.ReadLine();
        }
    }
}
