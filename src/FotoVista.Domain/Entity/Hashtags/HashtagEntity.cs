using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FotoVista.Domain.Entity;

public class HashtagEntity : Auditable
{
    [Required]
    [StringLength(25)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [Column("update_at")]
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
}
