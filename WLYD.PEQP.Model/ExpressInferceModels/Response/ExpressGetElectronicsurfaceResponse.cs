using Compeng.PEQP.Model.ExpressInferceModels.Enums;

namespace Compeng.PEQP.Model.ExpressInferceModels.Response
{
    /// <summary>
    /// 快递电子面单响应实体
    /// </summary>
    public class ExpressGetElectronicsurfaceResponse
    {
        /// <summary>
        /// 用户 ID
        /// </summary>
        public string EBusinessID { get; set; }

        /// <summary>
        /// 成功与否(true/false)
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 返回编码
        /// </summary>
        public ExpressInterfaceResponseStatusCode ResultCode { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string UniquerRequestNumber { get; set; }

        /// <summary>
        /// 订单预计到货时间
        /// </summary>
        public string EstimatedDeliveryTime { get; set; }

        /// <summary>
        /// 运单信息
        /// </summary>
        public ExpressOrder Order { get; set; }
    }

    /// <summary>
    /// 运单信息
    /// </summary>
    public class ExpressOrder
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        public string LogisticCode { get; set; }

        /// <summary>
        /// 大头笔
        /// </summary>
        public string MarkDestination { get; set; }

        /// <summary>
        /// 签回单单号
        /// </summary>
        public string SignWaybillCode { get; set; }

        /// <summary>
        /// 始发地区域编码
        /// </summary>
        public string OriginCode { get; set; }

        /// <summary>
        /// 始发地/始发网点
        /// </summary>
        public string OriginName { get; set; }

        /// <summary>
        /// 目的地区域编码
        /// </summary>
        public string DestinatioCode { get; set; }

        /// <summary>
        /// 目的地/到达网点
        /// </summary>
        public string DestinatioName { get; set; }

        /// <summary>
        /// 分拣编码
        /// </summary>
        public string SortingCode { get; set; }

        /// <summary>
        /// 集包编码
        /// </summary>
        public string PackageCode { get; set; }

        /// <summary>
        /// 集包地
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// 目的地分拨
        /// </summary>
        public string DestinationAllocationCentre { get; set; }

        /// <summary>
        /// 二维码信息
        /// </summary>
        public string QRCode { get; set; }

        /// <summary>
        /// 快递托运面单信息
        /// </summary>
        public ExpressShipperInfo ShipperInfo { get; set; }
    }

    /// <summary>
    /// 快递托运面单信息
    /// </summary>
    public class ExpressShipperInfo
    {
        /// <summary>
        /// 快递单号
        /// </summary>
        public string LogisticCode { get; set; }

        /// <summary>
        /// 原寄地中转场
        /// </summary>
        public string OriginTransferCode { get; set; }

        /// <summary>
        /// 原寄地城市代码
        /// </summary>
        public string OriginCityCode { get; set; }

        /// <summary>
        /// 原寄地网点代码
        /// </summary>
        public string OriginDeptCode { get; set; }

        /// <summary>
        /// 原寄地单元区域
        /// </summary>
        public string OriginTeamCode { get; set; }

        /// <summary>
        /// 目的地城市代码
        /// </summary>
        public string DestCityCode { get; set; }

        /// <summary>
        /// 目的地网点代码
        /// </summary>
        public string DestDeptCode { get; set; }

        /// <summary>
        /// 目的地网点代码映射码
        /// </summary>
        public string DestDeptCodeMapping { get; set; }

        /// <summary>
        /// 目的地单元区域
        /// </summary>
        public string DestTeamCode { get; set; }

        /// <summary>
        /// 目的地单元区域映射码
        /// </summary>
        public string DestTeamCodeMapping { get; set; }

        /// <summary>
        /// 目的地中转场
        /// </summary>
        public string DestTransferCode { get; set; }

        /// <summary>
        /// 打单时的路由标签信息
        /// </summary>
        public string DestRouteLabel { get; set; }

        /// <summary>
        /// 入港映射码
        /// </summary>
        public string CodingMapping { get; set; }

        /// <summary>
        /// 出港映射码
        /// </summary>
        public string CodingMappingOut { get; set; }

        /// <summary>
        /// XB 标志0:不需要打印1:需要打印
        /// </summary>
        public string XbFlag { get; set; }

        /// <summary>
        /// 打印标志
        /// </summary>
        public string PrintFlag { get; set; }

        /// <summary>
        /// 二维码
        /// </summary>
        public string TwoDimensionCode { get; set; }

        /// <summary>
        /// 时效类型:值为二维码中的 K4
        /// </summary>
        public string ProCode { get; set; }

        /// <summary>
        /// 打印图标
        /// </summary>
        public string PrintIcon { get; set; }

        /// <summary>
        /// AB 标
        /// </summary>
        public string AbFlag { get; set; }
    }
}
