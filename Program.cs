using GameAppWebAPI.DependencyInjection;
using GameAppWebAPI.Helpers;
using GameAppWebAPI.Services;
using GameAppWebAPI.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddFrontEndDI();
builder.Services.AddDataAccessLayerDI();
builder.Services.

builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddControllers();
builder.Services.AddCors();

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

//global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();
