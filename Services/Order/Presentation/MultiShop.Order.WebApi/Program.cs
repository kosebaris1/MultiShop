
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers.Read;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers.Write;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Read;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Write;

namespace MultiShop.Order.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
