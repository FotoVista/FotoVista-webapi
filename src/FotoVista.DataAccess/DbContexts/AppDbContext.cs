using Microsoft.EntityFrameworkCore;
using FotoVista.Domain.Entity;
namespace FotoVista.DataAccess.DbContexts;

public class AppDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<LikeEntity> Likes { get; set; }
    public DbSet<FollowerEntity> Followers { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<HashtagEntity> Hashtags { get; set; }
    public DbSet<PostHashtagEntity> PostHashtags { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

}

