using ASPWebAPIAdminAssignment.Model;
using ASPWebAPIAdminAssignment.Repository;
using Microsoft.EntityFrameworkCore;

namespace ASPWebAPIAdminAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //1--Connection String setting as Middleware

            builder.Services.AddDbContext<AdminDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PropelJanConnection")));


            //2--Repository as Middleware

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

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
