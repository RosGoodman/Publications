

using System.IO;

namespace Publications.WPF.Infrastructure.Serializers;

public abstract class AppSerializer<T>
{
    public abstract void Serialize(T value, Stream stream);

    public abstract T? Deserialize(Stream stream);
}
