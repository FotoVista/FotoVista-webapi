using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FotoVista.Domain.Entity.Posts;
using FotoVista.Domain.Entity.Users;

namespace FotoVista.Domain.Entity.Likes;

public class LikeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public long PostId { get; set; }

    [Required]
    public long UserId { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey("PostId")]
    public PostEntity Post { get; set; } = default!;

    [ForeignKey("UserId")]
    public UserEntity User { get; set; } = default!;
}
