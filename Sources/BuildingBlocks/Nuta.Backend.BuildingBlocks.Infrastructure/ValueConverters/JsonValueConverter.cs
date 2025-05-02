using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nuta.Backend.BuildingBlocks.Infrastructure.ValueConverters;

public class JsonValueConverter<T>() : ValueConverter<T, string>(
    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
    v => JsonSerializer.Deserialize<T>(v, (JsonSerializerOptions?)null)!);