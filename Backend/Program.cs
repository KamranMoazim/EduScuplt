using AutoMapper;
using AspNetCoreRateLimit;
using Backend.Mapper;
using Backend.Models;
using Backend.Middlewares;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Backend.Repositories.AuthRepo;
using Backend.Repositories.CourseRepo;
using Microsoft.EntityFrameworkCore;
using Backend.Repositories.CourseFolderRepo;
using Backend.Repositories.TagRepo;
using Backend.Repositories.CommentRepo;
using Backend.Repositories.InterestRepo;
using Backend.Repositories.InstructorRepo;
using Stripe;
using Backend.Repositories.StripeRepo;
using Backend.Repositories.StudentRepo;
using Backend.Repositories.CourseVideoRepo;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
// builder.Services.AddAutoMapper(MapperProfile);
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<ProjectAppContext>();
// builder.Services.AddIdentity<ProjectAppContext, IdentityRole>()
//     .AddEntityFrameworkStores<ProjectAppContext>()
//     .AddDefaultTokenProviders();

// StripeConfiguration.ApiKey = "sk_test_51IEw0JBssRAZJMFRFd26wS5Izc7r53lYpV9cgcU0UcM2Bbb799vJY58JbcVMhM9TZqzexlaV1gvArcWLtW9oeR9x00qMpjnR3L";
StripeConfiguration.ApiKey = "sk_test_51IEw0JBssRAZJMFRft7YUEnbiCnbcduo5dEswLICerDOhXdyL4b1IRnXEJdMLuHfbeUwoCVvGHgnCb3z8qbqqdSD007337Ix0a";


builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseFolderRepository, CourseFolderRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IInterestRepository, InterestRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseVideoRepository, CourseVideoRepository>();


// StripeConfiguration.ApiKey = builder.Configuration.GetValue<string>("StripeSettings:SecretKey");
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ChargeService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<CardService>();
builder.Services.AddScoped<IStripeRepository, StripeRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddStripeInfrastructure(builder.Configuration);


// for rate limiting
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>(); // Add this line


// builder.Services.AddIdentity<User, IdentityRole<int>>()
//     .AddEntityFrameworkStores<ProjectAppContext>()
//     .AddDefaultTokenProviders();

// for jwt
builder.Services.AddAuthentication(options =>
{
    // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM")),
        ValidateIssuer = true,
        ValidIssuer = "http://localhost:61955",
        ValidateAudience = true,
        ValidAudience = "http://localhost:4200",
        // ValidAudience = builder.Configuration["JWT:ValidAudience"],
        // ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
// builder.Services.AddAuthentication().AddJwtBearer();


builder.Services.AddEndpointsApiExplorer();

// for swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EduScuplt API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer jhfdkj.jkdsakjdsa.jkdsajk\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
            },
            new string[] { }
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }


app.UseSwagger();
app.UseSwaggerUI();

// Database initialization
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ProjectAppContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}


app.UseHttpsRedirection();


// my custom middleware for jwt to convert jwt to user 
app.UseJwtToUserMiddleware();


app.UseIpRateLimiting();


// my custom middleware for global exception handling
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();
app.MapGet("/", () => "Hello World from KAMRAN!");



// app.Run();
app.Run("http://0.0.0.0:9090");

/*
  "Kestrel": {
    "EndPoints": {
      "Http": {
        "Url": "http://localhost:9090"
      }
    }
  },
*/