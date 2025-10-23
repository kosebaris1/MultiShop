
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers.Read;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers.Write;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Read;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Write;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Mapping;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repository;

namespace MultiShop.Order.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.Audience = "ResourceOrder";
                opt.RequireHttpsMetadata = false;
            });

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(MapperProfile));


            builder.Services.AddScoped<GetAdressQueryHandler>();
            builder.Services.AddScoped<GetAdressByIdQueryHandler>();
            builder.Services.AddScoped<CreateAdressCommandHandler>();
            builder.Services.AddScoped<UpdateAdressCommandHandler>();
            builder.Services.AddScoped<RemoveAdressCommandHandler>();

            builder.Services.AddScoped<GetAllOrderDetailQueryHandler>();
            builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
            builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
            builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
            builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();


          


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
