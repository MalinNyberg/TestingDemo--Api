using Microsoft.EntityFrameworkCore;
using TestingRepApiDemo.Data;
using TestingRepApiDemo.Handlers;
using TestingRepApiDemo.Repositories;

namespace TestingRepApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
            builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString));
            builder.Services.AddScoped<IDogPictureRepository, DbDogPictureRepository>();
            var app = builder.Build();

            app.MapGet("/tag", DogPictureHandlers.ListTags);
            app.MapGet("/tag/{tag}", DogPictureHandlers.GetPicturesForTag);
            app.MapPost("/tag/{tag}", DogPictureHandlers.AddDogPicture);

            app.Run();
        }
    }
}