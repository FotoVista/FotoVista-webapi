using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoVista.Domain.Entity;

public class FollowerEntity : Auditable
{

    [Required]
    public long UserId { get; set; }

    [Required]
    [Column("follower_user_id")]
    public long FollowerUserId { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey("UserId")]
    public UserEntity User { get; set; } = default!;

    [ForeignKey("FollowerUserId")]
    public UserEntity FollowerUser { get; set; } = default!;
}
