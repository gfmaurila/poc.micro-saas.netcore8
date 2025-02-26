using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common.Core._08.Helper;

public class NullableGuidConverter : JsonConverter<Guid?>
{
    public override Guid? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && reader.GetInt64() == 0)
        {
            return null;
        }

        if (reader.TokenType == JsonTokenType.String && Guid.TryParse(reader.GetString(), out var guid))
        {
            return guid;
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, Guid? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString());
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
