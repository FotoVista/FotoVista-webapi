using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoVista.Domain.Entity;

public class PostHashtagEntity : Auditable
{
    [Required]
    public long PostId { get; set; }

    [Required]
    public long HashtagId { get; set; }

    [Required]
    [Column("create_at")]
    public DateTime CreateAt { get; set; } = DateTime.Now;

    [Required]
    [Column("update_at")]
    public DateTime UpdateAt { get; set; } = DateTime.Now;

    [ForeignKey("PostId")]
    public PostEntity Post { get; set; } = default!;

    [ForeignKey("HashtagId")]
    public HashtagEntity Hashtag { get; set; } = default!;
}
