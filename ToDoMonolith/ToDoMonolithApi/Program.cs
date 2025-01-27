using Microsoft.EntityFrameworkCore;
using ToDoMonolithApi.Core;

namespace ToDoMonolithApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<UserCore>();
        builder.Services.AddAutoMapper(typeof(Program));

        // Add services to the container.
        builder.Services.AddDbContext<ToDoMonolithContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("ToDoMonolithDbConnectionString"));
        });

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
