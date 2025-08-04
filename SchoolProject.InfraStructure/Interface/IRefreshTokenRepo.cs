using SchoolProject.Data.Entities.Idenitiy;
using SchoolProject.InfraStructure.InfrastrucherBase;

namespace SchoolProject.InfraStructure.Interface
{
    public interface IRefreshTokenRepo : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
