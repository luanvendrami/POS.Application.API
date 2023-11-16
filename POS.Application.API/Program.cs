using AutoMapper;
using Domain.Dto.Request;
using FluentValidation;
using FluentValidation.AspNetCore;
using IoC.infra;
using POS.Application.API.FluentValidation;
using Service.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Injections();

builder.Services.AddTransient<IValidator<DrinkOrderDto>, DrinkOrderDtoValidator>();
builder.Services.AddTransient<IValidator<GrillOrderDto>, GrillOrderDtoValidator>();
builder.Services.AddTransient<IValidator<OrderFriesDto>, OrderFriesDtoValidator>();
builder.Services.AddTransient<IValidator<SaladOrderDto>, SaladOrderDtoValidator>();

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddLogging();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
