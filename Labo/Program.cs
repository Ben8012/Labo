using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Services;
using labo.Tools;
using Labo.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Text;
using Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

                                                            // addSingleton = une instance pour tout les utilisateurs de l'application
//injection token
builder.Services.AddScoped<ITokenManager, TokenManager>(); // addScoped = une instance par client

//injection user
builder.Services.AddScoped<IUserDal, UserDalService>();
builder.Services.AddScoped<IUserBll, UserBllService>();

//injection account
builder.Services.AddScoped<IAccountDal, AccountDalService>();
builder.Services.AddScoped<IAccountBll, AccountBllService>();

//injection Transaction
builder.Services.AddScoped<ITransactionDal, TransactionDalService>();
builder.Services.AddScoped<ITransactionBll, TransactionBllService>();

//injection budget
builder.Services.AddScoped<IBudgetDal, BudgetDalService>();
builder.Services.AddScoped<IBudgetBll, BudgetBllService>();

//injection category
builder.Services.AddScoped<ICategoryDal, CategoryDalService>();
builder.Services.AddScoped<ICategoryBll, CategoryBllService>();

string connectionString = builder.Configuration.GetConnectionString("Labo");
// service de connection a la base de donnée
builder.Services.AddTransient<Connection>(sp => new Connection(SqlClientFactory.Instance, connectionString));// addTransient == une instance par demande

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// service gestion Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            //ValidateIssuerSigningKey = true,
            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            //    builder.Configuration.GetSection("TokenInfo").GetSection("secret").Value))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Auth", policy => policy.RequireAuthenticatedUser());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
