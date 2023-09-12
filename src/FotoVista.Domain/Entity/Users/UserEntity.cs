using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoVista.Domain.Entity;

public class UserEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public long RoleId { get; set; }

    [Required]
    [StringLength(50)]
    [Column("firstname")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [Column("lastname")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [Column("username")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Column("password_hash")]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    [Column("salt")]
    public string Salt { get; set; } = string.Empty;

    [Required]
    [Column("profile_picture_url")]
    public string ProfilePictureUrl { get; set; } = string.Empty;

    [Required]
    [Column("bio")]
    public string Bio { get; set; } = string.Empty;

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey("RoleId")]
    public RoleEntity Role { get; set; } = default!;
}
