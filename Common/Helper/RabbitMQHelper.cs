﻿using RabbitMQ.Client;
using System;

namespace Common.Helper
{
    public static class RabbitMQHelper
    {
        static Lazy<IConnection> _connection = new Lazy<IConnection>(CreateConnection);
        public static IConnection GetConnection => _connection.Value;
        static IConnection CreateConnection()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            return connection;
        }
    }
}