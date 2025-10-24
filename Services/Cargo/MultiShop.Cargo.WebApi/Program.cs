
using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;

namespace MultiShop.Cargo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
            builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
            builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
            builder.Services.AddScoped<ICargoCustomerService, CargoCustomeManager>();
            builder.Services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
            builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
            builder.Services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
            builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<CargoContext>(options =>
                options.UseSqlServer(connectionString));
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
