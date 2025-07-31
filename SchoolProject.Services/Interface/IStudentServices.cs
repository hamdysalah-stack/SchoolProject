using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Services.Interface
{
    public interface IStudentServices
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdwithIincludeAsync(int id);
        public Task<string> AddStudentAsync(Student student);
        public Task<string> EditStudentAsync(Student student);
        public Task<bool> IsNameExist(string name);

        public Task<bool> IsNameExistExcludeSlef(string name, int id);
        public Task<string> DeleteAsync(Student student);

        public Task<Student> GetByIdAsyncwithoutinclude(int id);
        public IQueryable<Student> GetStudentQuarable();

        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderbyEnum, string Search);

    }
}
