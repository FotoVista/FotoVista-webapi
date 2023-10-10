﻿namespace FotoVista.Service.DTOs;

public class HashtagResultDto
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }
}
