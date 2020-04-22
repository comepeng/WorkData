using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Compeng.PEQP.Model.Enums;

namespace Compeng.PEQP.Model.ExpressInferceModels.Request
{
    /// <summary>
    /// 快递电子面单请求实体
    /// </summary>
    public class ExpressGetElectronicsurfaceRequest
    {
        /// <summary>
        /// 用户自定义回传字段
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// ERP 系统、电商平台等系统或平台类型用户的会员 ID 或店铺账号等唯一性标识，用于区分其用户
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        ///  ShipperCode为SF可不填,电子面单客户账号
        /// </summary>       
        public string CustomerName { get; set; }

        /// <summary>
        ///  ShipperCode为SF可不填,电子面单客户密码
        /// </summary>
        public string CustomerPwd { get; set; }

        /// <summary>
        /// 网点名称
        /// </summary>
        public string SendSite { get; set; }

        /// <summary>
        /// ShipperCode为SF,月结卡号必填
        /// </summary>
        public string MonthCode { get; set; }

        /// <summary>
        /// 商家自定义区域
        /// </summary>
        public string CustomArea { get; set; }

        /// <summary>
        /// 发货仓编码(ShipperCode 为JDKY 时必填)
        /// </summary>
        public string WareHouseID { get; set; }

        /// <summary>
        /// 运输方式1-陆运，2-空运，不填默认为1
        /// </summary>
        public int? TransType { get; set; } = 1;

        /// <summary>
        /// 快递公司编码必填,填写范围:YTO(圆通),SF(顺丰),STO(申通),ZTO(中通)
        /// </summary>
        [Required]
        public ExpressCompanyCode ShipperCode { get; set; }

        /// <summary>
        /// 快递单号(仅宅急送可用)
        /// </summary>
        public string LogisticCode { get; set; }

        /// <summary>
        /// 第三方订单号(ShipperCode 为 JD 且ExpType 为 1 时必填)
        /// </summary>
        public string ThrOrderCode { get; set; }

        /// <summary>
        /// 订单编号(自定义，不可重复)
        /// </summary>
        [Required]
        public string OrderCode { get; set; }

        /// <summary>
        /// 运费支付方式：1-现付，2-到付，3-月结，4-第三方付(仅 SF、KYSY 支持)
        /// </summary>
        [Required]
        public int PayType { get; set; }

        /// <summary>
        /// 快递公司业务类型
        /// </summary>
        [Required]
        public string ExpType { get; set; }

        /// <summary>
        /// 是否要求签回单 0-不要求，1-要求
        /// </summary>
        public int? IsReturnSignBill { get; set; } = 0;

        /// <summary>
        /// 签回单操作要求(如：签名、盖章、身份证复印件等)
        /// </summary>
        public string OperateRequire { get; set; }

        /// <summary>
        /// 快递运费
        /// </summary>
        public decimal? Cost { get; set; }

        /// <summary>
        /// 是否要求签回单 0-不要求，1-要求
        /// </summary>
        public decimal? OtherCost { get; set; }

        /// <summary>
        /// 收件人信息
        /// </summary>
        public ExpressReceiver Receiver { get; set; }

        /// <summary>
        /// 发件人信息
        /// </summary>
        public ExpressSender Sender { get; set; }

        /// <summary>
        /// 是否通知快递员上门揽件 0-通知，1-不通知，不填则默认为 1
        /// </summary>
        public int? IsNotice { get; set; } = 1;

        /// <summary>
        /// 上门揽件时间段，格式：YYYY-MM-DD HH24:MM:SS
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 上门揽件时间段，格式：YYYY-MM-DD HH24:MM:SS
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 包裹总重量 kg
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// 包裹数
        /// </summary>
        public int? Quantity { get; set; } = 1;

        /// <summary>
        /// 包裹总体积 cm3
        /// </summary>
        public decimal? Volume { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 增值服务
        /// </summary>
        public List<ExpressAddService> AddService { get; set; }

        /// <summary>
        /// 包裹总体积 m3
        /// </summary>
        public List<ExpressCommodity> Commodity { get; set; }
    }

    /// <summary>
    /// 收件人信息
    /// </summary>
    public class ExpressReceiver
    {
        /// <summary>
        /// 收件人公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 收件人电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 收件人手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 收件地邮编(ShipperCode 为EMS、YZPY、YZBK 时必填)
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 收件省
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 收件市
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 收件区/县
        /// </summary>
        public string ExpAreaName { get; set; }

        /// <summary>
        /// 收件人详细地址
        /// </summary>
        public string Address { get; set; }
    }

    /// <summary>
    /// 发件人信息
    /// </summary>
    public class ExpressSender
    {
        /// <summary>
        /// 发件人公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 发件人
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 发件人电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 发件人手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 发件人邮编(ShipperCode 为EMS、YZPY、YZBK 时必填)
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 发件省
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 发件市
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 发件区/县
        /// </summary>
        public string ExpAreaName { get; set; }

        /// <summary>
        /// 发件人详细地址
        /// </summary>
        public string Address { get; set; }
    }

    /// <summary>
    /// 增值服务
    /// </summary>
    public class ExpressAddService
    {
        /// <summary>
        /// 增值服务名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 增值服务值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 客户标识
        /// </summary>
        public string CustomerID { get; set; }
    }

    /// <summary>
    /// 商品信息
    /// </summary>
    public class ExpressCommodity
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string GoodsCode { get; set; }

        /// <summary>
        /// 商品件数
        /// </summary>
        public int? GoodsQuantity { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal? GoodsPrice { get; set; }

        /// <summary>
        /// 商品重量 kg
        /// </summary>
        public decimal? GoodsWeight { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string GoodsDesc { get; set; }

        /// <summary>
        /// 商品体积 m3
        /// </summary>
        public decimal? GoodsVol { get; set; }
    }
}
