using Compeng.PEQP.Dto.Enums;

namespace Compeng.PEQP.Dto.Dtos
{
    /// <summary>
    /// 根据运单信息获取发货人信息，收货人信息等
    /// </summary>
    public class GetWaybillInfoRequestDto
    {
        /// <summary>
        /// 运单号
        /// </summary>
        public string WaybillNo { get; set; }

        /// <summary>
        /// 快递枚举，0为顺丰，其他待后续扩展
        /// </summary>
        public int Express { get; set; }
    }
}