using API.Interface;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("AMORTIZATION_SQL_CONNECTIONSTRING");
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IMortgageService, MortgageService>(); 
            builder.Services.AddScoped<IMortgageRepository, MortgageRepository>();
            builder.Services.AddScoped<IMortgageCalculatorDBContext, MortgageCalculatorDBContext>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MortgageCalculatorDBContext>(options => options.UseSqlServer(connection));
            var app = builder.Build();
             
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
               
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}