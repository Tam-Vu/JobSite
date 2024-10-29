using JobSite.Infrastructure;
using JobSite.Application;
using JobSite.Api;
var builder = WebApplication.CreateBuilder(args);
{
    builder.AddApplicationBuilder()
        .AddInfrastructureBuilder();

    builder.Services.AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddInfrastructureService(builder.Configuration)
        .AddPresentation()
        .AddApplicationService(builder.Configuration)
        .AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:3000");
            });
        });
}

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.AddInfrastructureApplication();
// app.UseHttpsRedirection();
app.Run();

