using Common.Helper;
using Common.Interfaces;
using RabbitMQ.Client;
using System;

namespace Producer.Exchanges.FanoutExchange
{
    public class FanoutMessage : ISendMessage
    {
        public string Message1 => "First Fanout Message";
        public string Message2 => "Second Fanout Message";
        public string Message3 => "Third Fanout Message";

        public bool SendMessage()
        {
            try
            {
                var connection = RabbitMQHelper.GetConnection;
                var channel = connection.CreateModel();

                channel.BasicPublish(FanoutExchange.EXCHANGE_NAME, FanoutExchange.ROUTING_KEY, null, Message1.GetBytes());

                channel.BasicPublish(FanoutExchange.EXCHANGE_NAME, FanoutExchange.ROUTING_KEY, null, Message2.GetBytes());

                channel.BasicPublish(FanoutExchange.EXCHANGE_NAME, FanoutExchange.ROUTING_KEY, null, Message3.GetBytes());
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}