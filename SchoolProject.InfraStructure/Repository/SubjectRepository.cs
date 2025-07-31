using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.InfraStructure.Data;
using SchoolProject.InfraStructure.InfrastrucherBase;
using SchoolProject.InfraStructure.Interface;

namespace SchoolProject.InfraStructure.Repository
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepository
    {

        #region  Fileds
        private DbSet<Subjects> Subject;
        #endregion


        #region constructor
        public SubjectRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            Subject = dBContext.Set<Subjects>();
        }



        #endregion



        #region  Handle Fucnction
        #endregion
    }
}
