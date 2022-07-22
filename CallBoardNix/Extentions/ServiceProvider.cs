using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataLayer.Repository;

namespace CallBoardNix.Extentions
{
    public static class ServiceProvider
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IRepository, GenericRepository>();
        }
    }
}
