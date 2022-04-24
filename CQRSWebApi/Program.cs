using CQRS_DAL.Context;
using CQRS_DAL.CQRS.Handlers.CommandHandlers;
using CQRS_DAL.CQRS.Handlers.QueryHandlers;
using CQRS_DAL.Repository.Dapper;
using CQRS_DAL.UoW;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContextPool<CQRSContext>(options => options.UseMySql("server=localhost;database=cqrsdb;user=root;port=3306;password=toortoor", new MySqlServerVersion(new Version(8, 0, 28))));
builder.Services.AddMediatR(typeof(CQRSContext));
builder.Services.AddTransient<CreateProductCommandHandler>();
builder.Services.AddTransient<DeleteProductCommandHandler>();
builder.Services.AddTransient<GetAllProductQueryHandler>();
builder.Services.AddTransient<GetProductByIdQueryHandler>();
builder.Services.AddScoped<IDapperProductRepository, DapperProductRepository>();

builder.Services.AddControllers();
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
