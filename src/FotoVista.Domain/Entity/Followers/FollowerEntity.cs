﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FotoVista.Domain.Entity.Users;

namespace FotoVista.Domain.Entity.Followers;

public class FollowerEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

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
