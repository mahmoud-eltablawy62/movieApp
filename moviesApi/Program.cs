using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using moviesApi.Models;
using moviesApi.services;
using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace moviesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext <MovieDbContext> (options => options.UseSqlServer(connection) );
            builder.Services.AddTransient<IGenraServ, GenraServ>();
            builder.Services.AddTransient<IMovieServ, MovieServ>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();
            builder.Services.AddSwaggerGen(
                
                options => {
                    options.SwaggerDoc(name: "v1", info: new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "MoviesApi",
                        Description = "MovieApp",
                        
                        Contact = new OpenApiContact
                        {
                            Name = "mahmoud",
                            Email = "mahmoud eltablawy",
                        },
                        License = new OpenApiLicense
                        {
                            Name = "License",
                            Url = new Uri(uriString: "https://www.google.com"),
                        }
                    });
                }); 
            

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