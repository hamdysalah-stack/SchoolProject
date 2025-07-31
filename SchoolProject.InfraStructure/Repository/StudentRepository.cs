

using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SchoolProject.Data.Entities;
using SchoolProject.InfraStructure.Data;
using SchoolProject.InfraStructure.InfrastrucherBase;
using SchoolProject.InfraStructure.Interface;

namespace SchoolProject.InfraStructure.Repository
{
    public class StudentRepository:GenericRepositoryAsync<Student>, IStudentRepository
    {

        #region  fields
        //private readonly ApplicationDBContext _dBContext;
        private readonly DbSet<Student> _students;
        #endregion

        #region constructor
        public StudentRepository(ApplicationDBContext dBContext) : base(dBContext) 
        {
            //_dBContext = dBContext;
            _students = dBContext.Set<Student>();

        }
        #endregion


        #region  HandelFucntuion    
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _students.Include(x=>x.Department).ToListAsync();


        }

        //public async Task<Student> GetStudentByIdAsync(int id)
        //{
        //    //var Student = await _students.FindAsync(id);
        //    //return Student;
        //    var Student = await _students.Include(x => x.Department)
        //                                 .Where(d => d.StudID.Equals(id))
        //                                 .FirstOrDefaultAsync();
        //    return Student!;
        }


        #endregion


    }
