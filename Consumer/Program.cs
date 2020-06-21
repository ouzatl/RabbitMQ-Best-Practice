using Common.Helper;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consumer
{
    static class Program
    {
        static void Main(string[] args)
        {
            bool result;

            var queueList= new List<string>();
            queueList.Add("direct-queue-1");
            queueList.Add("direct-queue-2");
            queueList.Add("direct-queue-3");
            queueList.Add("fanout-queue-1");
            queueList.Add("fanout-queue-2");
            queueList.Add("fanout-queue-3");
            queueList.Add("topic-queue-1");
            queueList.Add("topic-queue-2");
            queueList.Add("topic-queue-3");
            queueList.Add("header-queue-1");
            queueList.Add("header-queue-2");
            queueList.Add("header-queue-3");

            foreach (var queueName in queueList)
            {
                result = CreateConsumer(queueName);
                if (result)
                    Console.WriteLine(queueName + " mesajları işlendi.");
                else
                    Console.WriteLine(queueName + " mesajları işlenemedi.");
            }

            Console.WriteLine("Tüm mesajlar işlendi.");
            Console.ReadKey();
        }

        static bool CreateConsumer(string queue)
        {
            try
            {
                var connection = RabbitMQHelper.GetConnection;
                var channel = connection.CreateModel();
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = body.GetString();
                    Console.WriteLine($"{queue} Received {body.GetString()}", message);
                };
                channel.BasicConsume(queue: queue,
                                     autoAck: true,
                                     consumer: consumer);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }


    //public class Person
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public string SurName { get; set; }
    //    public DateTime BirthDate { get; set; }
    //    public string Message { get; set; }
    //}
}