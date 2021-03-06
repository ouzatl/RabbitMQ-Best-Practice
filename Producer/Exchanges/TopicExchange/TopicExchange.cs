﻿using Common.Helper;
using Common.Interfaces;
using RabbitMQ.Client;

namespace Producer.Exchanges.TopicExchange
{
    public class TopicExchange : IExchangeFactory
    {
        public const string EXCHANGE_NAME = "topic-exchange";

        public const string QUEUE_NAME_1 = "topic-queue-1";
        public const string QUEUE_NAME_2 = "topic-queue-2";
        public const string QUEUE_NAME_3 = "topic-queue-3";

        public const string ROUTING_PATTERN_1 = "asia.china.*";
        public const string ROUTING_PATTERN_2 = "asia.china.#";
        public const string ROUTING_PATTERN_3 = "asia.*.*";

        public const string ROUTING_KEY_1 = "asia.china.nanjing";
        public const string ROUTING_KEY_2 = "asia.china";
        public const string ROUTING_KEY_3 = "asia.china.beijing";

        public void CreateExChangeAndQueue()
        {
            var connection = RabbitMQHelper.GetConnection;
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Topic, true);

            channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_PATTERN_1);

            channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_PATTERN_2);

            channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_PATTERN_3);
        }
    }
}