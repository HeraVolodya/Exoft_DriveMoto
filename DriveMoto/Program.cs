
using DriveMoto.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
 
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
 
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddDbContext<ClientsAPIDbContext>(options => options.UseInMemoryDatabase("ClientsDb"));
builder.Services.AddDbContext<APIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ClientsApiConnectionString")));

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
