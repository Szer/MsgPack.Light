using System.Runtime.Serialization;

namespace ProGaudi.MsgPack.Light.Converters.Generation.Exceptions
{
    public class GeneratorException : SerializationException
    {
        public GeneratorException(string message)
            : base(message)
        {
        }
    }
}