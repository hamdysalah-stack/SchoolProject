
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Services.Interface;
using SchoolProject.Services.Services;

namespace SchoolProject.Services
{
    public static class ModuleServicesDependencies
    {

        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentServices, StudentServices>();
            services.AddTransient<IdepartmentServices, departmentServices>();
            return services;
        }
    }
}
