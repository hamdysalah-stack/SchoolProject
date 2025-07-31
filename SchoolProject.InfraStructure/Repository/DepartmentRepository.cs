using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.InfraStructure.Data;
using SchoolProject.InfraStructure.InfrastrucherBase;
using SchoolProject.InfraStructure.Interface;

namespace SchoolProject.InfraStructure.Repository
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region  Fileds
        private DbSet<Department> departments;
        #endregion


        #region constructor
        public DepartmentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            departments = dBContext.Set<Department>();
        }



        #endregion



        #region  Handle Fucnction
        #endregion
    }
}
