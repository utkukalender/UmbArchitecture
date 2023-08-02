using Core.Core.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Umb.Application;
using Umb.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(x =>
{
    x.Cookie.Name = "UmbSession";
    x.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
    x.Cookie.HttpOnly= true;
    x.Cookie.IsEssential = true;

});

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseLoggingMiddleware();
app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
