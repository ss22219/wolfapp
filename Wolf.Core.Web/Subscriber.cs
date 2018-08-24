using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wolf.Core.Web
{
    public class Subscriber
    {
        public void TestEventHandler(TestEvent testEvent)
        {
            Console.WriteLine("Subscriber TestEventHandler");
        }

        public void TestMessageHandler(TestMessage testMessage)
        {
            Console.WriteLine("Subscriber TestMessageHandler");
        }

        //public void TestEventExceptionHandler(TestEvent testEvent)
        //{
        //    throw new Exception("Test");
        //}

        //public void TestEventWithVersionHandler(TestEventWithVersion testEventWithVersion)
        //{

        //}

        //public void TestEventExceptionWithVersionHandler(TestEventWithVersion testEventWithVersion)
        //{
        //    throw new Exception("Test");
        //}

    }
}
