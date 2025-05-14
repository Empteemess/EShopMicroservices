﻿using System.Text.Json.Serialization;

namespace Catalog.Api.Models;

public class ErrorDetails
{
    public string? ErrorType { get; set; }
    public string? Message { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Field { get; set; }
}