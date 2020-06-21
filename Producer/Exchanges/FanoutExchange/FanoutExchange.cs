﻿using Common.Helper;
using Common.Interfaces;
using RabbitMQ.Client;

namespace Producer.Exchanges.FanoutExchange
{
    public class FanoutExchange : IExchangeFactory
    {
        public const string EXCHANGE_NAME = "fanout-exchange";
        public const string QUEUE_NAME_1 = "fanout-queue-1";
        public const string QUEUE_NAME_2 = "fanout-queue-2";
        public const string QUEUE_NAME_3 = "fanout-queue-3";

        public static string ROUTING_KEY = "";
        public void CreateExChangeAndQueue()
        {
            var connection = RabbitMQHelper.GetConnection;
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Fanout, true);

            channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_KEY);

            channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_KEY);

            channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_KEY);
        }
    }
}