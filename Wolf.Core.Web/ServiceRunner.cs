using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zaabee.RabbitMQ.Abstractions;

namespace Wolf.Core.Web
{
    /// <summary>
    /// Mq消费者
    /// </summary>
    public class ServiceRunner
    {
        private readonly IZaabeeRabbitMqClient _messageBus;

        /// <summary>
        /// 通过CI获取ServiceCollection中的MqClient
        /// </summary>
        /// <param name="messageBus"></param>
        public ServiceRunner(IZaabeeRabbitMqClient messageBus)
        {
            _messageBus = messageBus;
        }

        public void Start()
        {
            //            _messageBus.ReceiveEvent<TestEvent>(TestEventHandler);
            //            _messageBus.SubscribeEvent<TestEvent>(new Subscriber().TestEventHandler);
            Console.WriteLine("ServiceRunner started");

            //每次取10条（默认）
            _messageBus
                .SubscribeEvent<TestEvent>(() => new Subscriber().TestEventHandler);
            //            _messageBus.ReceiveEvent<TestEvent>(TestEventExceptionHandler);
            //            _messageBus.SubscribeEvent<TestEvent>(TestEventExceptionHandler);
            //            _messageBus.ReceiveEvent<TestEventWithVersion>(TestEventWithVersionHandler);
            //            _messageBus.ReceiveEvent<TestEventWithVersion>(TestEventExceptionWithVersionHandler, 20);
            //            _messageBus.ReceiveMessage<TestMessage>(TestMessageHandler);
            //            _messageBus.SubscribeMessage<TestMessage>(TestMessageHandler);
            //            _messageBus.ListenMessage<TestMessage>(TestMessageHandler);
            //            _messageBus.RepublishDeadLetterEvent<TestEvent>(
            //                "dead-letter-EmailApplication.EmailEventHandler.Handle[EmailContract.EmailCommand]");
            //            _messageBus.RepublishDeadLetterEvent<TestEvent>(
            //                "dead-letter-Demo.TestEvent");
        }
    }
}
