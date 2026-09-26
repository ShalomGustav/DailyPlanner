using DailyPlanner.Application.DependencyInjection;
using DailyPlanner.Domain.DependencyInjection;
using DailyPlanner.Http.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAplication();
builder.Services.AddDomain(builder.Configuration);
builder.Services.AddHttp();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
