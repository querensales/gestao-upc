﻿using System.ComponentModel.DataAnnotations;

namespace Repository.Entity;

public record CreditCard
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
}
