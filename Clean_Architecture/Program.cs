using Certificate.Application;
using Certificate.Infrastructure;
using Certificate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });

    builder.Services.AddInfrastructureServices();
    builder.Services.AddApplicationService();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}
// Add services to the container.



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

// Configure the HTTP request pipeline.




//app.UseAuthorization();




