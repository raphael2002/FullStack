using InventoryHub.Api.Middleware;
using InventoryHub.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InventoryService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
