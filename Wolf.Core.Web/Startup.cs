using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Zaabee.RabbitMQ;
using Zaabee.RabbitMQ.Abstractions;
using Zaabee.RabbitMQ.ISerialize;
using Zaabee.RabbitMQ.Json;

namespace Wolf.Core.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ServiceRunner, ServiceRunner>();
            services.AddSingleton<ISerializer, Serializer>();
            services.AddSingleton<IZaabeeRabbitMqClient, ZaabeeRabbitMqClient>(p =>

                new ZaabeeRabbitMqClient(new MqConfig
                {
                    AutomaticRecoveryEnabled = true,
                    HeartBeat = 60,
                    NetworkRecoveryInterval = new TimeSpan(60),
                    Hosts = new List<string> { "wolfapp.cn" },
                    UserName = "guest",
                    Password = "guest"
                }, services.BuildServiceProvider().GetService<ISerializer>())

                );
            services.AddMvc();
        }

        // ͨ��ci�Զ�����ServiceRunner
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ServiceRunner runner)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index"}
               );
            });

            //�����߿�ʼ������Ϣ
            runner.Start();
        }
    }
}
