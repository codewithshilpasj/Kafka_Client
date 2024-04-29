using Confluent.Kafka;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
// Copyright 2016-2018 Confluent Inc., 2015-2016 Andreas Heider
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Derived from: rdkafka-dotnet, licensed under the 2-clause BSD License.
//
// Refer to LICENSE for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


/// <summary>
///     Demonstrates use of the Consumer client.
/// </summary>
using System;
using Confluent.Kafka;

class Program
{
    public static class KafkaConsumerConfig
    {
        public static ConsumerConfig GetConfig()
        {
            return new ConsumerConfig
            {
                //please note the below won't work, it's just a dummmy value
                BootstrapServers = "pkc-123445.us-west2.gcp.confluent.cloud:9092", // Replace with your Kafka broker address
                GroupId = "KafkaExampleConsumer",
                SaslUsername = "H5ISR7VLKQN", //replace with your username
                SaslPassword = "deZ3KznyLsFwXFBXrVEZct/7JGjWjGgtx3yvVagfIO2vEq1x", //replace with your saslpassword
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false,
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.SaslSsl
            };
        }
    }
    static void Main()
    {
        var config = KafkaConsumerConfig.GetConfig();
        string topic = "topic_0"; // Replace with your topic name
        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

        consumer.Subscribe(topic);
        while (true)
        {
            try
            {
                var consumeResult = consumer.Consume();
                Console.WriteLine($"Received message: {consumeResult.Message.Value}");

                // Process the message here
                consumer.Commit(consumeResult);
            }
            catch (ConsumeException e)
            {
                Console.WriteLine($"Error consuming message: {e.Error.Reason}");
            }
        }
    }
}

namespace Confluent.Kafka.Examples.ProducerExample
{
    public class Program
    {
        //public static async Task Main(string[] args)
        //{
        //    //if (args.Length != 2)
        //    //{
        //    //    Console.WriteLine("Usage: .. brokerList topicName");
        //    //    return;
        //    //}

        //    //string brokerList = args[0];
        //    //string topicName = args[1];

        //    var config = new ProducerConfig
        //    {
       
        //please note the below won't work, it's just a dummmy value
                //BootstrapServers = "pkc-123445.us-west2.gcp.confluent.cloud:9092", // Replace with your Kafka broker address
                //SaslUsername = "H5ISR7VLKQN", //replace with your username
                //SaslPassword = "deZ3KznyLsFwXFBXrVEZct/7JGjWjGgtx3yvVagfIO2vEq1x", //replace with your saslpassword
                //SaslMechanism = SaslMechanism.Plain,
                //SecurityProtocol = SecurityProtocol.SaslSsl
        //    };



        //    using (var producer = new ProducerBuilder<string, string>(config).Build())
        //    {
        //        Console.WriteLine("\n-----------------------------------------------------------------------");
        //        Console.WriteLine($"Producer {producer.Name} producing on topic topic_0");
        //        Console.WriteLine("-----------------------------------------------------------------------");
        //        Console.WriteLine("To create a kafka message with UTF-8 encoded key and value:");
        //        Console.WriteLine("> key value<Enter>");
        //        Console.WriteLine("To create a kafka message with a null key and UTF-8 encoded value:");
        //        Console.WriteLine("> value<enter>");
        //        Console.WriteLine("Ctrl-C to quit.\n");

        //        var cancelled = false;
        //        Console.CancelKeyPress += (_, e) => {
        //            e.Cancel = true; // prevent the process from terminating.
        //            cancelled = true;
        //        };

        //        while (!cancelled)
        //        {
        //            Console.Write("> ");

        //            string text;
        //            try
        //            {
        //                text = Console.ReadLine();
        //            }
        //            catch (IOException)
        //            {
        //                // IO exception is thrown when ConsoleCancelEventArgs.Cancel == true.
        //                break;
        //            }
        //            if (text == null)
        //            {
        //                // Console returned null before 
        //                // the CancelKeyPress was treated
        //                break;
        //            }

        //            string key = null;
        //            string val = text;

        //            // split line if both key and value specified.
        //            int index = text.IndexOf(" ");
        //            if (index != -1)
        //            {
        //                key = text.Substring(0, index);
        //                val = text.Substring(index + 1);
        //            }

        //            try
        //            {
        //                // Note: Awaiting the asynchronous produce request below prevents flow of execution
        //                // from proceeding until the acknowledgement from the broker is received (at the 
        //                // expense of low throughput).
        //                var deliveryReport = await producer.ProduceAsync(
        //                    "topic_0", new Message<string, string> { Key = key, Value = val });

        //                Console.WriteLine($"delivered to: {deliveryReport.TopicPartitionOffset}");
        //            }
        //            catch (ProduceException<string, string> e)
        //            {
        //                Console.WriteLine($"failed to deliver message: {e.Message} [{e.Error.Code}]");
        //            }
        //        }

        //        // Since we are producing synchronously, at this point there will be no messages
        //        // in-flight and no delivery reports waiting to be acknowledged, so there is no
        //        // need to call producer.Flush before disposing the producer.
        //    }
        //}
    }
}