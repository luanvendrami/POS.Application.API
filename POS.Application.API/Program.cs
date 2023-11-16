using AutoMapper;
using Domain.Dto.Request;
using FluentValidation;
using FluentValidation.AspNetCore;
using IoC.infra;
using IoC.infra.MappingAutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using POS.Application.API.FluentValidation;
using System.Reflection;

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

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api POS", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API POS V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
