using Microsoft.EntityFrameworkCore;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.Repository;

namespace ProductSalesWebAPIAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //1--Connection String setting as Middleware

            builder.Services.AddDbContext<ProductSalesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PropelJanConnection")));


            //2--Repository as Middleware

            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IStaffProductRepository, StaffProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IStoreRepository, StoreRepository>();
            builder.Services.AddScoped<IStockRepository, StockRepository>();

            //2--Service as Middleware


            //4--JWT Token



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
