﻿using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.Accounts;

public class UserDto
{
    public string? Id { get; set; }
    public string UserName { get; set; }

    public string Email { get; set; }
    public string? PhoneNumber { get; set; }

    public string? Role { get; set; }

    // [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public LoginDto? Credentials { get; set; }
}
