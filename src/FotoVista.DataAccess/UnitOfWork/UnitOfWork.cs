using FotoVista.DataAccess.DbContexts;
using FotoVista.DataAccess.IRepository;
using FotoVista.DataAccess.Repository;
using FotoVista.Domain.Entity;

namespace FotoVista.DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IRepository<UserEntity> UserRepository { get; }
    public IRepository<RoleEntity> RoleRepository { get; }
    public IRepository<PostEntity> PostRepository { get; }
    public IRepository<CommentEntity> CommentRepository { get; }
    public IRepository<LikeEntity> LikeRepository { get; }
    public IRepository<HashtagEntity> HashtagRepository { get; }
    public IRepository<PostHashtagEntity> PostHashtagRepository { get; }
    public IRepository<FollowerEntity> FollowerRepository { get; }

    public IRepository<Following> FollowingRepository { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        UserRepository = new Repository<UserEntity>(_context);
        RoleRepository = new Repository<RoleEntity>(_context);
        PostRepository = new Repository<PostEntity>(_context);
        CommentRepository = new Repository<CommentEntity>(_context);
        LikeRepository = new Repository<LikeEntity>(_context);
        HashtagRepository = new Repository<HashtagEntity>(_context);
        PostHashtagRepository = new Repository<PostHashtagEntity>(_context);
        FollowerRepository = new Repository<FollowerEntity>(_context);
        FollowingRepository = new Repository<Following>(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

