using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoVista.Domain.Entity;

public class LikeEntity : Auditable
{
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
