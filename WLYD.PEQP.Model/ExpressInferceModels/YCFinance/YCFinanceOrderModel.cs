using System;
using System.Collections.Generic;

namespace Compeng.PEQP.Model.ExpressInferceModels.YCFinance
{
    /// <summary>
    /// 入库单
    /// </summary>
    public class YCPurchaseOrderModel
    {
        public YCPurchaseOrderModel()
        {
            Products = new List<object>();
        }
        /// <summary>
        /// 来源平台原始订单编号
        /// </summary>
        public string SourceOrderNo { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 来源平台名称
        /// </summary>
        public string ExternalSystemName { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// ERP编号
        /// </summary>
        public string ERPOrderNo { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 订单备注
        /// </summary>
        public string OrderDesc { get; set; }

        #region 收货信息
        /// <summary>
        /// 收货人
        /// </summary>
        public string ReceiverPerson { get; set; }

        /// <summary>
        /// 收货公司
        /// </summary>
        public string ReceiverCompany { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string ReceiverMobile { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 收货地址省份
        /// </summary>
        public string ReceiverProvince { get; set; }

        /// <summary>
        /// 收货地址市
        /// </summary>
        public string ReceiverCity { get; set; }

        /// <summary>
        /// 收货地址县
        /// </summary>
        public string ReceiverCounty { get; set; }

        /// <summary>
        /// 收货城市邮编
        /// </summary>
        public string ReceiverPostCode { get; set; }
        #endregion

        #region 发件人信息

        /// 发件方
        /// </summary>
        public string SenderCompany { get; set; }

        /// 发件人
        /// </summary>
        public string SenderPerson { get; set; }

        /// <summary>
        /// 发件人联系电话
        /// </summary>
        public string SenderMobile { get; set; }

        /// <summary>
        /// 发件地址
        /// </summary>
        public string SenderAddress { get; set; }

        /// <summary>
        /// 发件省
        /// </summary>
        public string SenderProvince { get; set; }

        /// <summary>
        /// 发件市
        /// </summary>
        public string SenderCity { get; set; }

        /// <summary>
        /// 发件县
        /// </summary>
        public string SenderCounty { get; set; }

        /// <summary>
        /// 寄件方邮编
        /// </summary>
        public string SenderPostCode { get; set; }
        #endregion

        public List<object> Products { get; set; }

        public List<ExtendProperty> ExtendProperties { get; set; }
    }

    /// <summary>
    /// 出库单
    /// </summary>
    public class YCSaleOrderModel
    {
        public YCSaleOrderModel()
        {
            Products = new List<object>();
        }

        /// <summary>
        /// 来源平台原始订单编号
        /// </summary>
        public string SourceOrderNo { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 来源平台名称
        /// </summary>
        public string ExternalSystemName { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// ERP编号
        /// </summary>
        public string ERPOrderNo { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 买家昵称
        /// </summary>
        public string BuyerNick { get; set; }

        #region 收货信息
        /// <summary>
        /// 收货人
        /// </summary>
        public string ReceiverPerson { get; set; }

        /// <summary>
        /// 收货公司
        /// </summary>
        public string ReceiverCompany { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string ReceiverMobile { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 收货地址省份
        /// </summary>
        public string ReceiverProvince { get; set; }

        /// <summary>
        /// 收货地址市
        /// </summary>
        public string ReceiverCity { get; set; }

        /// <summary>
        /// 收货地址县
        /// </summary>
        public string ReceiverCounty { get; set; }

        /// <summary>
        /// 收货城市邮编
        /// </summary>
        public string ReceiverPostCode { get; set; }
        #endregion

        #region 发件人信息

        /// 发件方
        /// </summary>
        public string SenderCompany { get; set; }

        /// 发件人
        /// </summary>
        public string SenderPerson { get; set; }

        /// <summary>
        /// 发件人联系电话
        /// </summary>
        public string SenderMobile { get; set; }

        /// <summary>
        /// 发件地址
        /// </summary>
        public string SenderAddress { get; set; }

        /// <summary>
        /// 发件省
        /// </summary>
        public string SenderProvince { get; set; }

        /// <summary>
        /// 发件市
        /// </summary>
        public string SenderCity { get; set; }

        /// <summary>
        /// 发件县
        /// </summary>
        public string SenderCounty { get; set; }

        /// <summary>
        /// 寄件方邮编
        /// </summary>
        public string SenderPostCode { get; set; }
        #endregion

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime? PayTime { get; set; }

        /// <summary>
        /// 揽件时间
        /// </summary>
        public DateTime? CollectTime { get; set; }

        /// <summary>
        /// 签收时间
        /// </summary>
        public DateTime? SignTime { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal? OrderAmt { get; set; }

        /// <summary>
        /// 订单优惠金额
        /// </summary>
        public decimal? OrderDiscount { get; set; }

        /// <summary>
        /// 订单实际支付金额
        /// </summary>
        public decimal? OrderPayment { get; set; }

        /// <summary>
        /// 订单备注
        /// </summary>
        public string OrderDesc { get; set; }

        /// <summary>
        /// 物流公司名称
        /// </summary>
        public string LogisticsName { get; set; }

        /// <summary>
        /// 物流公司编码
        /// </summary>
        public string LogisticsCode { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        public string LogisticsNo { get; set; }

        public List<object> Products { get; set; }

        public List<ExtendProperty> ExtendProperties { get; set; }

    }

    /// <summary>
    /// 异常订单
    /// </summary>
    public class YCReturnOrderModel
    {
        /// <summary>
        /// 退货单单号
        /// </summary>
        public string ReturnOrderCode { get; set; }

        /// <summary>
        /// 退货单的原发货单号
        /// </summary>
        public string OriginalERPOrderNo { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 异常件原因（TH-退货；HH-换货；WTJ-物流问题件）
        /// </summary>
        public string ExceptionStatus { get; set; }
    }

    /// <summary>
    /// 扩展属性
    /// </summary>
    public class ExtendProperty
    {
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        public string PropertyValue { get; set; }
    }

    public class YCOrderProduct
    {

        /// <summary>
        /// 外部商品编码
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string ProductUnit { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal? ProductPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal ProductNum { get; set; }

        /// <summary>
        /// 订单行号
        /// </summary>
        public string OrderLineNo { get; set; }

        /// <summary>
        /// 商品规格
        /// </summary>
        public string ProductSpec { get; set; }

        /// <summary>
        /// 1：正品，2：残次品
        /// </summary>
        public int InventoryType { get; set; }
    }
}
