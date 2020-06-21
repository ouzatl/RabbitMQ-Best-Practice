using Common.Helper;
using Common.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;

namespace Producer.Exchanges.HeadersExchange
{
    public class HeadersMessage : ISendMessage
    {
        public string Message1 => "First Header Message";
        public string Message2 => "Second Header Message";
        public string Message3 => "Third Header Message";

        public bool SendMessage()
        {
            try
            {
                var connection = RabbitMQHelper.GetConnection;
                var channel = connection.CreateModel();
                var props = channel.CreateBasicProperties();


                var map1 = new Dictionary<string, object>();
                map1.Add("First", "A");
                map1.Add("Fourth", "D");
                props.Headers = map1;
                channel.BasicPublish(HeadersExchange.EXCHANGE_NAME, "", props, Message1.GetBytes());

                var props2 = channel.CreateBasicProperties();
                var map2 = new Dictionary<string, object>();
                map2.Add("Third", "C");
                props2.Headers = map2;
                channel.BasicPublish(HeadersExchange.EXCHANGE_NAME, "", props2, Message2.GetBytes());

                var props3 = channel.CreateBasicProperties();
                var map3 = new Dictionary<string, object>();
                map3.Add("First", "A");
                map3.Add("Third", "C");
                props3.Headers = map3;
                channel.BasicPublish(HeadersExchange.EXCHANGE_NAME, "", props3, Message3.GetBytes());
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}