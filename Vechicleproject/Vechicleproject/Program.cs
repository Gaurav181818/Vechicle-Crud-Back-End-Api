using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Implementation;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using DataAccessLayer.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(VehicleProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IVehicleRepository>(_ => new VehicleRepository(connectionString));
builder.Services.AddScoped<IVehicleService, VehicleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseCors(
    builder => builder
        .WithOrigins("http://localhost:3000") // Front URL
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
