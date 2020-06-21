using Common.Interfaces;
using Newtonsoft.Json;
using Producer.Exchanges.DirectExchange;
using Producer.Exchanges.FanoutExchange;
using Producer.Exchanges.HeadersExchange;
using Producer.Exchanges.TopicExchange;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var exhangeFactory = CreateExchange(ExchangeType.Direct);
            exhangeFactory.CreateExChangeAndQueue();
            var producer = CreateSendMessage(ExchangeType.Direct);
            var result = producer.SendMessage();
            if (result)
                Console.WriteLine("Direct Exchange -" +"Mesajlar Queue'lara iletildi.");

            var exhangeFactory2 = CreateExchange(ExchangeType.Fanout);
            exhangeFactory2.CreateExChangeAndQueue();
            var producer2 = CreateSendMessage(ExchangeType.Fanout);
            producer2.SendMessage();
            if (result)
                Console.WriteLine("Fanout Exchange -" + "Mesajlar Queue'lara iletildi.");

            var exhangeFactory3 = CreateExchange(ExchangeType.Topic);
            exhangeFactory3.CreateExChangeAndQueue();
            var producer3 = CreateSendMessage(ExchangeType.Topic);
            producer3.SendMessage();
            if (result)
                Console.WriteLine("Topic Exchange -" + "Mesajlar Queue'lara iletildi.");

            var exhangeFactory4 = CreateExchange(ExchangeType.Headers);
            exhangeFactory4.CreateExChangeAndQueue();
            var producer4 = CreateSendMessage(ExchangeType.Headers);
            producer4.SendMessage();
            if (result)
                Console.WriteLine("Headers Exchange -" + "Mesajlar Queue'lara iletildi.");

            Console.ReadKey();

        }

        public static ISendMessage CreateSendMessage(string exchangeType)
        {

            switch (exchangeType)
            {
                case ExchangeType.Direct:
                    return new DirectMessage();
                case ExchangeType.Headers:
                    return new HeadersMessage();
                case ExchangeType.Topic:
                    return new TopicMessage();
                case ExchangeType.Fanout:
                    return new FanoutMessage();
                default:
                    throw new Exception("there is no properly exchange type");
            }
        }

        public static IExchangeFactory CreateExchange(string exchangeType)
        {

            switch (exchangeType)
            {
                case ExchangeType.Direct:
                    return new DirectExchange();
                case ExchangeType.Headers:
                    return new HeadersExchange();
                case ExchangeType.Topic:
                    return new TopicExchange();
                case ExchangeType.Fanout:
                    return new FanoutExchange();
                default:
                    throw new Exception("there is no properly exchange type");
            }
        }
    }
//Person person = new Person() { Name = "Oğuz", SurName = "Atlı", ID = 1, BirthDate = new DateTime(1978, 6, 3), Message = "İlgili aday yakınımdır :)" };
    //var factory = new ConnectionFactory() { HostName = "localhost" };
    //using (IConnection connection = factory.CreateConnection())
    //using (IModel channel = connection.CreateModel())
    //{
    //    channel.QueueDeclare(queue: "X",
    //                         durable: false,
    //                         exclusive: false,
    //                         autoDelete: false,
    //                         arguments: null);

    //    string message = JsonConvert.SerializeObject(person);
    //    var body = Encoding.UTF8.GetBytes(message);

    //    channel.BasicPublish(exchange: "",
    //                         routingKey: "Borsoft",
    //                         basicProperties: null,
    //                         body: body);
    //    Console.WriteLine($"Gönderilen kişi: {person.Name}-{person.SurName}");
    //}

    //Console.WriteLine(" İlgili kişi gönderildi...");
    //Console.ReadLine();
    //(ExchangeType.Topic, ExchangeType.Headers, ExchangeType.Fanout, ExchangeType.Direct)

    //public class Person
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public string SurName { get; set; }
    //    public DateTime BirthDate { get; set; }
    //    public string Message { get; set; }
    //}
}
