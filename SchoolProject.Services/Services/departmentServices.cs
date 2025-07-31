using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.InfraStructure.Interface;
using SchoolProject.Services.Interface;

namespace SchoolProject.Services.Services
{
    internal class departmentServices : IdepartmentServices
    {


        #region fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructor

        public departmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Handle Function

        public async Task<Department> GetDepartmentById(int id)
        {
            var student = await _departmentRepository.GetTableNoTracking().Where(x => x.DID.Equals(id))
                                                        .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subjects)
                                                         .Include(x => x.Students)
                                                         .Include(x => x.Instructors)
                                                         .Include(x => x.Supervisor).FirstOrDefaultAsync();

            return student!;

        }

        #endregion
    }
}
