using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoVista.Domain.Entity;

public class CommentEntity : Auditable 
{

    [Required]
    public long PostId { get; set; }

    [Required]
    public long UserId { get; set; }

    [Required]
    [Column("text")]
    public string Text { get; set; } = string.Empty;

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey("PostId")]
    public PostEntity Post { get; set; } = default!;

    [ForeignKey("UserId")]
    public UserEntity User { get; set; } = default!;
}

