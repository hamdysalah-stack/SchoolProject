using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.InfraStructure.Interface;
using SchoolProject.Services.Interface;

namespace SchoolProject.Services.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _StudentRepository;

        public StudentServices(IStudentRepository studentRepository)
        {
            _StudentRepository = studentRepository;
        }




        public async Task<List<Student>> GetStudentsListAsync()

        {

            return await _StudentRepository.GetStudentsListAsync();
        }


        public async Task<Student> GetStudentByIdwithIincludeAsync(int id)
        {
            //var Student = await _StudentRepository.GetByIdAsync(id);
            //return Student;

            var Student = _StudentRepository.GetTableNoTracking()
                                                   .Include(x => x.Department)
                                                   .Where(d => d.StudID.Equals(id))
                                                   .FirstOrDefault();

            return Student!;



        }

        public async Task<string> AddStudentAsync(Student student)
        {
            //// Check if the name exists or not
            //var existingStudent = _StudentRepository.GetTableNoTracking()
            //                                        .Where(x => x.Name.Equals(student.Name))
            //                                        .FirstOrDefault();
            //if (existingStudent != null)
            //{
            //    return ("Student is Exist");
            //}
            // Add Student
            await _StudentRepository.AddAsync(student);
            return "Student added successfully";
        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await _StudentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameExist(string name)
        {
            // Check if the name exists or not
            var Student = _StudentRepository.GetTableNoTracking()
                                                    .Where(x => x.Name.Equals(name))
                                                    .FirstOrDefault();
            if (Student != null) return false;
            return true;




        }

        public async Task<bool> IsNameExistExcludeSlef(string name, int id)
        {
            // Check if the name exists or not
            var Student = await _StudentRepository.GetTableNoTracking()
                                                    .Where(x => x.Name.Equals(name) & !x.StudID.Equals(id))
                                                    .FirstOrDefaultAsync();
            if (Student != null) return false;
            return true;
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var tarns = _StudentRepository.BeginTransaction();

            try
            {
                await _StudentRepository.DeleteAsync(student);
                await tarns.CommitAsync();
                return "Success";
            }

            catch
            {
                await tarns.RollbackAsync();
                return "Falied";
            }



        }

        public Task<Student> GetByIdAsyncwithoutinclude(int id)
        {
            var Student = _StudentRepository.GetByIdAsync(id);

            return Student!;
        }

        public IQueryable<Student> GetStudentQuarable()
        {
            return _StudentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderbyEnum, string Search)
        {
            var Qurable = _StudentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (Search != null)
            {
                Qurable = Qurable.Where(x => x.Name.Contains(Search) || x.Address.Contains(Search) || x.Department.DName.Contains(Search));
            }

            switch (orderbyEnum)
            {
                case StudentOrderingEnum.StudID: Qurable = Qurable.OrderBy(x => x.StudID); break;
                case StudentOrderingEnum.Name: Qurable = Qurable.OrderBy(x => x.Name); break;
                case StudentOrderingEnum.Address: Qurable = Qurable.OrderBy(x => x.Address); break;
                case StudentOrderingEnum.DepartmantName: Qurable = Qurable.OrderBy(x => x.Department.DName); break;
                default: Qurable = Qurable.OrderBy(x => x.StudID); break;
            }
            return Qurable;

        }
    }
}
