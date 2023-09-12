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

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // Configure the User entity
    //    modelBuilder.Entity<UserEntity>()
    //        .HasOne(u => u.Role)
    //        .WithMany()
    //        .HasForeignKey(u => u.RoleId);

    //    modelBuilder.Entity<UserEntity>()
    //        .HasIndex(u => u.Username)
    //        .IsUnique();

    //    modelBuilder.Entity<UserEntity>()
    //        .HasIndex(u => u.Email)
    //        .IsUnique();

    //    // Configure the Post entity
    //    modelBuilder.Entity<PostEntity>()
    //        .HasOne(p => p.User)
    //        .WithMany(u => u.Posts)
    //        .HasForeignKey(p => p.UserId);



    //    // Configure the Like entity
    //    modelBuilder.Entity<LikeEntity>()
    //        .HasOne(l => l.User)
    //        .WithMany()
    //        .HasForeignKey(l => l.UserId);

    //    // Configure the Comment entity
    //    modelBuilder.Entity<CommentEntity>()
    //        .HasOne(c => c.Post)
    //        .WithMany(p => p.Comments)
    //        .HasForeignKey(c => c.PostId);

    //    modelBuilder.Entity<CommentEntity>()
    //        .HasOne(c => c.User)
    //        .WithMany()
    //        .HasForeignKey(c => c.UserId);

    //    // Configure the Follower entity
    //    modelBuilder.Entity<FollowerEntity>()
    //        .HasOne(f => f.User)
    //        .WithMany()
    //        .HasForeignKey(f => f.UserId);

    //    modelBuilder.Entity<Follower>()
    //        .HasOne(f => f.FollowerUser)
    //        .WithMany()
    //        .HasForeignKey(f => f.FollowerUserId);

    //    // Configure the Hashtag entity
    //    modelBuilder.Entity<Hashtag>()
    //        .HasMany(h => h.PostHashtags)
    //        .WithOne(ph => ph.Hashtag)
    //        .HasForeignKey(ph => ph.HashtagId);

    //    // Configure the PostHashtag entity
    //    modelBuilder.Entity<PostHashtag>()
    //        .HasOne(ph => ph.Post)
    //        .WithMany(p => p.PostHashtags)
    //        .HasForeignKey(ph => ph.PostId);

    //    // ... (add more configurations and relationships as needed)

    //    base.OnModelCreating(modelBuilder);
    ////}
}

