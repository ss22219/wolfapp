﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Zaabee.RabbitMQ.Abstractions;

namespace Wolf.Core.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 利用RabbitMQ实现了消息总线，所以叫messageBus？
        /// </summary>
        IZaabeeRabbitMqClient _messageBus;

        /// <summary>
        /// 从ServiceCollection获取MqClient
        /// </summary>
        /// <param name="messageBus"></param>
        public HomeController(IZaabeeRabbitMqClient messageBus)
        {
            _messageBus = messageBus;
        }

        public ActionResult Index(int quantity = 1)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < quantity; i++)
            {
                _messageBus.PublishEvent(new TestEvent
                {
                    Id = Guid.NewGuid(),
                    Timestamp = DateTimeOffset.Now
                });
            }
            stopwatch.Stop();
            return Content(stopwatch.ElapsedMilliseconds.ToString());
        }
    }
}
