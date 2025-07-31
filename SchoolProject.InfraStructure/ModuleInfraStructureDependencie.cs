using Microsoft.Extensions.DependencyInjection;
using SchoolProject.InfraStructure.InfrastrucherBase;
using SchoolProject.InfraStructure.Interface;
using SchoolProject.InfraStructure.Repository;

namespace SchoolProject.InfraStructure
{
    public static class ModuleInfraStructureDependencie
    {

        public static IServiceCollection AddInfraStructureDependencies(this IServiceCollection services)
        {
            // Configuration of DI for GenericRepositoryAsync
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            //Congifation of DI IStudentRepository
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();



            return services;
        }

    }
}
