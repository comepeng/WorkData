namespace Compeng.Rpc.Client.Model
{
    /// <summary>
    /// 服务地址
    /// </summary>
    public class HostAndPort
    {
        /// <summary>
        /// Ip
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        private bool Equals(HostAndPort other)
        {
            return Ip == other.Ip && Port == other.Port;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HostAndPort) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Ip != null ? Ip.GetHashCode() : 0) * 397) ^ Port;
            }
        }
    }
}