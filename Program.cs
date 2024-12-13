
using Microsoft.EntityFrameworkCore;
using TrackFlow.Data;
using TrackFlow.Services;

namespace TrackFlow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string? connection = builder.Configuration.GetConnectionString("TrackFlowDatabase");

            // Add services to the container.

            // Add the Database Context
            builder.Services.AddDbContext<ContextTrackFlow>(opt => opt.UseSqlServer(connection)); 

            builder.Services.AddScoped<IServiceVehicule, ServiceVehicle>();

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
