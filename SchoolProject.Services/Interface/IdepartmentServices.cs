using SchoolProject.Data.Entities;

namespace SchoolProject.Services.Interface
{
    public interface IdepartmentServices
    {

        public Task<Department> GetDepartmentById(int id);
    }
}
