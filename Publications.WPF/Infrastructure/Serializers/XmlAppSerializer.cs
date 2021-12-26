

using System.IO;
using System.Xml.Serialization;

namespace Publications.WPF.Infrastructure.Serializers;

public class XmlAppSerializer<T> : AppSerializer<T>
{
    private readonly XmlSerializer _serializer;

    public XmlAppSerializer(XmlSerializer serializer) => _serializer = serializer;

    public override T? Deserialize(Stream stream)
    {
        return (T?)_serializer.Deserialize(stream);
    }

    public override void Serialize(T value, Stream stream)
    {
        _serializer.Serialize(stream, value);
    }
}
