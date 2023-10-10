using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FotoVista.Domain.Entity;

public class Following : Auditable
{
    [Required]
    public long UserId { get; set; }

    [Required]
    [Column("following_user_id")]
    public long FollowingUserId { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey("UserId")]
    public UserEntity User { get; set; } = default!;

    [ForeignKey("FollowingUserId")]
    public UserEntity FollowingUser { get; set; } = default!;
}
