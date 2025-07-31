using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.InfraStructure.Data;
using SchoolProject.InfraStructure.InfrastrucherBase;
using SchoolProject.InfraStructure.Interface;

namespace SchoolProject.InfraStructure.Repository
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region  Fileds
        private DbSet<Instructor> instructor;
        #endregion


        #region constructor
        public InstructorRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            instructor = dBContext.Set<Instructor>();
        }



        #endregion



        #region  Handle Fucnction
        #endregion
    }
}
