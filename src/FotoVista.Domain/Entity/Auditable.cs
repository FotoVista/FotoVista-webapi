using System.ComponentModel.DataAnnotations;

namespace FotoVista.Domain.Entities;

public abstract class Auditable : BaseEntity
{
    [Required]
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    [Required]
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
}
