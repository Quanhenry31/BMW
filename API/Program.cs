using BLL;
using BLL.Interfaces;
using BusinessLogicLayer;
using DAL;
using DAL.Interfaces;
using DataAccessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.Text;

const string corsPolicyName = "ApiCORS";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500");
    });
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
   /* options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500") // Thêm nguồn của bạn vào đây
            .AllowAnyMethod()
            .AllowAnyHeader();
    });

    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });*//* thêm cái này vào trong program*/


});

// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<ICarBLL, CarBLL>();
/// add user
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserBusiness, UserBusiness>();
// Add catelory to the container.
builder.Services.AddTransient<ICateRepository, CateRepository>();
builder.Services.AddTransient<ICateBusiness, CateBusiness>();
// user hand controllner
builder.Services.AddTransient<IUserHandRepository, UserHandRepository>();
builder.Services.AddTransient<IUserHandBusiness, UserHandBusiness>();


// configure strongly typed settings objects
IConfiguration configuration = builder.Configuration;
var appSettingsSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);



// configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,

    };
});

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
app.UseCors(corsPolicyName);
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
