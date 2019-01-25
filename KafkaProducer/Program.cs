using System;
using System.Collections.Generic;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace KafkaProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Topic");
            string topic = Console.ReadLine();

            Uri uri = new Uri("http://localhost:9092");
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var client = new Producer(router);
            while (true)
            {
                Console.WriteLine("Enter message:");
                string payload = Console.ReadLine();
                if (payload == "exit") { Environment.Exit(0); }
                Message msg = new Message(payload);
                client.SendMessageAsync(topic, new List<Message> { msg }).Wait();
            }
           // Console.ReadLine();
        }
    }
}
