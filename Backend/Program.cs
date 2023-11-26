using AutoMapper;
using AspNetCoreRateLimit;
using Backend.IRepositories;
using Backend.Mapper;
using Backend.Models;
using Backend.Repositories;
using Backend.Middlewares;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
// builder.Services.AddAutoMapper(MapperProfile);
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<ProjectAppContext>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>(); // Add this line

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseIpRateLimiting();

// app.Use(async (context, next) =>
// {
//     context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
//     context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
//     await next();
// });

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

// app.Run();

app.MapGet("/", () => "Hello World from KAMRAN!");

app.Run("http://0.0.0.0:9090");