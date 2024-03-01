using System.Text.Json;
using System.Text;

namespace MvcCoreSession.Helper.HelperBinarySection
{
    public class HelperBinarySection
    {
        public HelperBinarySection() { }

        public static byte[] ObjectToByte(Object objeto)
        {
            var ObjectSerializer = JsonSerializer.Serialize(objeto);
            byte[] bytes = Encoding.UTF8.GetBytes(ObjectSerializer);
            return bytes;
        }

        public static T? ByteToObject<T>(byte[] bytes)
        {
            var objeto = JsonSerializer.Deserialize<T>(bytes);
            return objeto;
        }
    }
}
