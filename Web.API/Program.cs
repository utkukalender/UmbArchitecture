using Core.Core.Logging;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Serilog;
using System.Globalization;
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
builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var supportedCultures = new List<CultureInfo>
    //DESTEKLENEN DÝLLERÝ EKLÝYORUM
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR"),
    };
    opt.DefaultRequestCulture = new RequestCulture("en-US");
    opt.SupportedCultures = supportedCultures;
    opt.SupportedUICultures = supportedCultures;
    opt.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider(),
        new AcceptLanguageHeaderRequestCultureProvider(),
    };
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
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(options.Value);
app.UseHttpsRedirection();
app.UseLoggingMiddleware();
app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
