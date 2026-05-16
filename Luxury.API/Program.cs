using Luxury.BusinessLayer.Settings;
using Luxury.BusinessLayer.DependencyInjection;
using Luxury.BusinessLayer.Mapping.MapProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMemoryCache();

builder.Services.AddBusinessLayerServices();
builder.Services.Configure<RapidApiOptions>(builder.Configuration.GetSection("RapidApi"));
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(opt => opt.AddMaps(typeof(MappingProfile)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
