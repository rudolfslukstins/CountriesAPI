using Countries.Core.AutoMapper;
using Countries.Data;
using Countries.Service;
using Refit;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddRefitClient<IApiDataConsumer>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://restcountries.com/"));

builder.Services
    .AddScoped<IOceaniaCountriesService,OceaniaCountriesService>();

builder.Services
    .AddSingleton(AutoMapperConfig.CreateMapper());

var app = builder.Build();
app.Logger.LogInformation("Starting the service.");
app.UseHttpLogging();
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
