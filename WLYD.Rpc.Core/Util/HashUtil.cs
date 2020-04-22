namespace Compeng.Rpc.Core.Util
{
    public static class HashUtil
    {
        /// <summary>
        /// Hash long.
        /// </summary>
        /// <param name="digest">the digest</param>
        /// <param name="index">the number</param>
        /// <returns>the long</returns>
        public static long Hash(this byte[] digest, int index)
        {
            var f = ((long) (digest[3 + index * 4] & 0xFF) << 24)
                    | ((long) (digest[2 + index * 4] & 0xFF) << 16)
                    | ((long) (digest[1 + index * 4] & 0xFF) << 8)
                    | ((long)(digest[index * 4] & 0xFF));
            f = f & 0xFFFFFFFFL;
            return f;
        }
    }
}