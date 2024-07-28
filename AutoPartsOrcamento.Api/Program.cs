using AutoPartsOrcamento.Api.Filters;
using AutoPartsOrcamento.Infra;
using AutoPartsOrcamento.Aplicacao.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.ClienteUseCase();
builder.Services.VeiculoUseCase();
builder.Services.OrcamentoUseCase();
builder.Services.ProdutoUseCase();
builder.Services.CotacaoUseCase();
builder.Services.StatusUseCase();
builder.Services.FornecedorUseCase();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(config => config.Filters.Add(typeof(ExceptionFilter)));

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

app.UseCors(x =>
    x.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.Run();
