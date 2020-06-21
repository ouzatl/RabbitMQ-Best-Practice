using Common.Helper;
using Common.Interfaces;
using RabbitMQ.Client;
using System;

namespace Producer.Exchanges.DirectExchange
{
    class DirectMessage : ISendMessage
    {
        public string Message1 => "First Direct Message";
        public string Message2 => "Second Direct Message";
        public string Message3 => "Third Direct Message";

        public bool SendMessage()
        {
            try
            {
                var connection = RabbitMQHelper.GetConnection;
                var channel = connection.CreateModel();

                // First message sent by using ROUTING_KEY_1
                channel.BasicPublish(DirectExchange.EXCHANGE_NAME, DirectExchange.ROUTING_KEY_1, null, Message1.GetBytes());

                // Second message sent by using ROUTING_KEY_2
                channel.BasicPublish(DirectExchange.EXCHANGE_NAME, DirectExchange.ROUTING_KEY_2, null, Message2.GetBytes());

                // Third message sent by using ROUTING_KEY_3
                channel.BasicPublish(DirectExchange.EXCHANGE_NAME, DirectExchange.ROUTING_KEY_3, null, Message3.GetBytes());
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}