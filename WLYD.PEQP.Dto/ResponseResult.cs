namespace Compeng.PEQP.Dto
{
    /// <summary>
    /// 响应结果泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Msg { get; set; }
    }

    /// <summary>
    /// 响应结果泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseResult<T> : ResponseResult
    {
        /// <summary>
        /// 返回的数据
        /// </summary>
        public T Data { get; set; }
    }
}