using JobSite.Infrastructure;
using JobSite.Application;
using JobSite.Api;
using Microsoft.AspNetCore.Mvc;
using JobSite.Infrastructure.Common.Persistence;
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddInfrastructureService(builder.Configuration)
        .AddApplicationService(builder.Configuration)
        .AddControllers();
    // .AddCors(options =>
    // {
    //     options.AddPolicy("CorsPolicy", builder =>
    //     {
    //         builder.AllowAnyHeader()
    //             .AllowAnyMethod()
    //             .WithOrigins("http://localhost:3000");
    //     });
    // });

    builder.AddApplicationBuilder()
    .AddInfrastructureBuilder()
    .AddPresentation();
}

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseHttpsRedirection();
app.UseExceptionHandler();
app.AddInfrastructureApplication();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var dbInitializer = services.GetService<DbInitializer>();
        dbInitializer!.SeedingData().Wait();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred creating the DB.");
    }
};

app.Run();

