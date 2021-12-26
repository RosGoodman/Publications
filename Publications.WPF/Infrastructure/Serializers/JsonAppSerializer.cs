

using System.IO;
using System.Text.Json;

namespace Publications.WPF.Infrastructure.Serializers;

public class JsonAppSerializer<T> : AppSerializer<T>
{
    public override T? Deserialize(Stream stream)
    {
        return JsonSerializer.Deserialize<T>(stream);
    }

    public override void Serialize(T value, Stream stream)
    {
        JsonSerializer.Serialize(stream, value);
    }
}
