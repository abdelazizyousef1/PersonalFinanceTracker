using Microsoft.EntityFrameworkCore;
using Personal_Finance_Tracker.Application.IServices;
using Personal_Finance_Tracker.Application.Services;
using Personal_Finance_Tracker.Infrastructure.FinanceDbContext;
using Personal_Finance_Tracker.Infrastructure.Repository;
using Personal_Finance_Tracker.Infrastructure.Repository.IRepository;
using Personal_Finance_Tracker.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ITransactionServices, TransactionServices>();
builder.Services.AddDbContext<FinanceContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("FinanceConnection")));




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
