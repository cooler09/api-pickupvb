using api_pickupvb.data;
using api_pickupvb.service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<EventContext>(options => options.UseMySQL(connectionString));
builder.Services.AddScoped<IEventService,EventService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var  allowedOrigins = "_allowOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins, policy  =>
    {
        policy.WithOrigins(
            "https://pickupvb.com",
            "http://pickupvb.com",
            "https://www.pickupvb.com",
            "http://www.pickupvb.com",
            "http://localhost:4200",
            "https://localhost:4200"
        ).AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowedOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
