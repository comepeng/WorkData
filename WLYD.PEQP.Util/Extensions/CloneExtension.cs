using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Compeng.PEQP.Util.Extensions
{
    public static class CloneExtension
    {
        public static T DeepClone<T>(this T obj) where T : class
        {
            T newObj = default(T);
            //将对象序列化成内存中的二进制流  
            BinaryFormatter inputFormatter = new BinaryFormatter();
            MemoryStream inputStream;
            using (inputStream = new MemoryStream())
            {
                inputFormatter.Serialize(inputStream, obj);
            }
            //将二进制流反序列化为对象  
            using (MemoryStream outputStream = new MemoryStream(inputStream.ToArray()))
            {
                BinaryFormatter outputFormatter = new BinaryFormatter();
                newObj = outputFormatter.Deserialize(outputStream) as T;
            }
            return newObj;
        }
    }
}
