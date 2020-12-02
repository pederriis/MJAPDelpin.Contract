using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
//using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MJAPDelpin.Contract.Application.Handlers.Query;
using MJAPDelpin.Contract.Application.Infrastructure;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Application.Requests.Command;
using MJAPDelpin.Contract.Application.Requests.Query;
using MJAPDelpin.Contract.Domain.Models;
using MJAPDelpin.Contract.Edge.InfrastructureInterfaces;
using MJAPDelpin.Contract.Edge.Mapping;
using MJAPDelpin.Contract.Edge.Repositories;
using MJAPDelpin.Contract.Application.Handlers;
using MJAPDelpin.Contract.Application.Handlers.Command;

namespace MJAPDelpin.Contract.Edge
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
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ordrehalløj",  
                    Version = "v1"
                });
            });


            services.AddControllers();
            services.AddSingleton<IStorageCommand, StorageCommand>();
            services.AddSingleton<IOrderQueryRepository, OrderQueryRepository>();
            services.AddSingleton<IMapper, MockMapper>();
            services.AddSingleton<IStorageQuery, StorageQuery>();
            services.AddSingleton<IRequestHandler<CreateOrderCommand, string>, CreateOrderHandler>();
            services.AddSingleton<IRequestHandler<QueryGetAllOrders, List<Order>>, GetAllOrdersHandler>();
            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)


        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order v1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
