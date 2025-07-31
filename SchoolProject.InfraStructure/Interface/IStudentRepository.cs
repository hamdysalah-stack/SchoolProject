
using SchoolProject.Data.Entities;
using SchoolProject.InfraStructure.InfrastrucherBase;

namespace SchoolProject.InfraStructure.Interface
{
    public  interface IStudentRepository:IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentsListAsync();
        //public Task<Student> GetStudentByIdAsync(int id);
    }
}
