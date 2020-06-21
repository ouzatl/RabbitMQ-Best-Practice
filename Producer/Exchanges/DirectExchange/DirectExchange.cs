using Common.Helper;
using Common.Interfaces;
using RabbitMQ.Client;

namespace Producer.Exchanges.DirectExchange
{
    public class DirectExchange : IExchangeFactory
    {
        public const string EXCHANGE_NAME = "direct-exchange";
        public const string QUEUE_NAME_1 = "direct-queue-1";
        public const string QUEUE_NAME_2 = "direct-queue-2";
        public const string QUEUE_NAME_3 = "direct-queue-3";
        public const string ROUTING_KEY_1 = "direct-key-1";
        public const string ROUTING_KEY_2 = "direct-key-2";
        public const string ROUTING_KEY_3 = "direct-key-3";
        public void CreateExChangeAndQueue()
        {
            var connection = RabbitMQHelper.GetConnection;
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Direct, true);

            // First Queue
            channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_KEY_1);

            // Second Queue
            channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_KEY_2);

            // Third Queue
            channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_KEY_3);


            //channel.ExchangeDelete(EXCHANGE_NAME, true);

            //channel.QueueDelete(QUEUE_NAME_1,false,false);

            //channel.QueuePurge(QUEUE_NAME_1);

        }
    }
}