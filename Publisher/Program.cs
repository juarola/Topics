using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.TopicExists("TestTopic"))
            {
                namespaceManager.CreateTopic("TestTopic");
            }


            var client = TopicClient.CreateFromConnectionString(connectionString, "TestTopic");

            client.Send(new BrokeredMessage());
        }
    }
}
