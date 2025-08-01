﻿namespace AppService.Domain.Registration.Request;

public record AddAccountRequest
{
    public string Name { get; set; }
    public Guid UserId { get; set; }
}
