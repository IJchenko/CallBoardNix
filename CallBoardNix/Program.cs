using BusinessLayer.Extension;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using CallBoardNix.Extentions;
using DataLayer.EF;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
// 
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IRepository, GenericRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();