﻿namespace AppService.Domain.Account.Request;

public record LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
