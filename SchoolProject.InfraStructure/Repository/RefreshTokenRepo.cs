using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Idenitiy;
using SchoolProject.InfraStructure.Data;
using SchoolProject.InfraStructure.InfrastrucherBase;
using SchoolProject.InfraStructure.Interface;

namespace SchoolProject.InfraStructure.Repository
{
    public class RefreshTokenRepo : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepo
    {

        #region  Fileds
        private DbSet<UserRefreshToken> _UserRefreshToken;
        #endregion


        #region constructor
        public RefreshTokenRepo(ApplicationDBContext dBContext) : base(dBContext)
        {
            _UserRefreshToken = dBContext.Set<UserRefreshToken>();
        }



        #endregion



        #region  Handle Fucnction
        #endregion
    }
}
