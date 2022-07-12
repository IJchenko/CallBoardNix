using BusinessLayer.Extension;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using CallBoardNix.Extentions;
using DataLayer.EF;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
// Add DbContext
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
// Add Identity
builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationContext>();
// Add AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile), typeof(AutoMapperViewProfile));
// Add services 
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IRepository, GenericRepository>();
//
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
// Add using JWT token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.Use(async (context, next) =>
{
    var token = context.Session.GetString("Token");
    if(!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer"+token);
    }
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
