using FotoVista.DataAccess.IRepository;
using FotoVista.Domain.Entity;
using static NPOI.HSSF.Util.HSSFColor;

namespace FotoVista.DataAccess.UnitOfWork;

public interface IUnitOfWork
{

    IRepository<UserEntity> UserRepository { get; }
    IRepository<RoleEntity> RoleRepository { get; }
    IRepository<PostEntity> PostRepository { get; }
    IRepository<CommentEntity> CommentRepository { get; }
    IRepository<LikeEntity> LikeRepository { get; }
    IRepository<HashtagEntity> HashtagRepository { get; }
    IRepository<PostHashtagEntity> PostHashtagRepository { get; }
    IRepository<FollowerEntity> FollowerRepository { get; }
    IRepository<Following> FollowingRepository { get; }


    Task<int> SaveAsync();
}