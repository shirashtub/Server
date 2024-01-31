using DAL.Data;
using DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using project.MiddleWares;
using Serilog;

namespace project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string Cors = "_cors";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITodoData, TodoData>();
            builder.Services.AddScoped<IPostData, PostData>();
            builder.Services.AddScoped<IPhotoData, PhotoData>();
            builder.Services.AddScoped<IUsersData, UsersData>();
            builder.Services.AddDbContext<ProjectContext>(item => item.UseSqlServer("Data Source=DESKTOP-55NP42S;Initial Catalog=MyPoject;Integrated Security=SSPI;Trusted_Connection=True;"));

            builder.Services.AddCors(op =>
            {
                op.AddPolicy(Cors, builder =>
                {
                    builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
                });
            });

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"C:\שלי\תכנות\פרויקט\server\log.txt", rollingInterval: RollingInterval.Day).CreateLogger();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorMiddleWare>();
            app.UseMiddleware<InfoMiddleWare>();

            app.UseCors(Cors);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}