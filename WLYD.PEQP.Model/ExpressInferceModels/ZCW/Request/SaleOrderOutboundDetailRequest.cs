using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compeng.PEQP.Model.ExpressInferceModels.ZCW.Request
{
    /// <summary>
    /// 出库单明细回传
    /// </summary>
    public class SaleOrderOutboundDetailRequest
    {
        /// <summary>
        /// 货主编码
        /// </summary>
        [XmlElement("CompanyCode")]
        public string CompanyCode { get; set; }


        [XmlArray("SaleOrders")]
        [XmlArrayItem("SaleOrder")]
        public List<SaleOrderOutboundDetail> SaleOrders { get; set; }
    }


    /// <summary>
    /// 出库单信息
    /// </summary>
    [Serializable]
    public class SaleOrderOutboundDetail 
    {

        /// <summary>
        /// 客户编号
        /// </summary>
        [XmlIgnore]
        public string CustomerCode { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("WarehouseCode")]
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 订单号码
        /// </summary>
        [XmlElement("ErpOrder")]
        public string ErpOrder { get; set; }

        /// <summary>
        /// 出库单号
        /// </summary>
        [XmlElement("ShipmentId")]
        public string ShipmentId { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("WayBillNo")]
        public string WayBillNo { get; set; }

        /// <summary>
        /// 回单号
        /// </summary>
        [XmlElement("ReturnTracking")]
        public string ReturnTracking { get; set; }

        /// <summary>
        /// 发货时间(格式YYYY-MM-DD HH24:MI:SS)
        /// </summary>
        [XmlElement("ActualShipDateTime")]
        public string ActualShipDateTime { get; set; }

        //[XmlIgnore]
        //public DateTime ActualShipDateTime
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(ActualShipDateTimeStr))
        //        {
        //            return DateTime.Parse(ActualShipDateTimeStr);
        //        }
        //        return DateTime.Now;
        //    }
        //}

        /// <summary>
        /// 承运商
        /// </summary>
        [XmlElement("Carrier")]
        public string Carrier { get; set; }

        /// <summary>
        /// 承运商产品
        /// </summary>
        [XmlElement("CarrierProduct")]
        public string CarrierProduct { get; set; }


        /// <summary>
        /// ERP订单类型
        /// </summary>
        [XmlElement("ErpOrderType")]
        public string ErpOrderType { get; set; }


        /// <summary>
        /// 发票号
        /// </summary>
        [XmlElement("InvoiceNo")]
        public string InvoiceNo { get; set; }


        /// <summary>
        /// 是否已拆单：Y-是，N-否
        /// </summary>
        [XmlElement("IsSplit")]
        public string IsSplit { get; set; }


        /// <summary>
        /// 订单状态
        ///1400:已取消
        ///2300:等待工作
        ///2700:包装完成
        ///2900:发货确认
        ///3900:订单已完成
        /// </summary>
        [XmlElement("DataStatus")]
        public string DataStatus { get; set; }



        /// <summary>
        /// 收件人
        /// </summary>
        [XmlElement("ReceiverName")]
        public string ReceiverName { get; set; }


        /// <summary>
        /// 收件人电话
        /// </summary>
        [XmlElement("ReceiverMobile")]
        public string ReceiverMobile { get; set; }


        /// <summary>
        /// 收件人地址
        /// </summary>
        [XmlElement("ReceiverAddress")]
        public string ReceiverAddress { get; set; }



        /// <summary>
        /// 发件人
        /// </summary>
        [XmlElement("SenderName")]
        public string SenderName { get; set; }


        /// <summary>
        /// 发件人电话
        /// </summary>
        [XmlElement("SenderMobile")]
        public string SenderMobile { get; set; }


        /// <summary>
        /// 发件人地址
        /// </summary>
        [XmlElement("SenderAddress")]
        public string SenderAddress { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef1")]
        public string UserDef1 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef2")]
        public string UserDef2 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef3")]
        public string UserDef3 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef4")]
        public string UserDef4 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef5")]
        public string UserDef5 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef6")]
        public string UserDef6 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef7")]
        public string UserDef7 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef8")]
        public string UserDef8 { get; set; }


        /// <summary>
        /// 订单金额
        /// </summary>
        [XmlElement("OrderAmount")]
        public string OrderAmount { get; set; }


        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<OrderProductDetail> Items { get; set; }


        [XmlArray("Containers")]
        [XmlArrayItem("Container")]
        public List<OrderPackageDetail> Containers { get; set; }

        

    }


    /// <summary>
    /// 商品信息
    /// </summary>
    [Serializable]
    public class OrderProductDetail
    {
        /// <summary>
        /// 订单行号
        /// </summary>
        [XmlElement("ErpOrderLineNum")]
        public Nullable<int> ErpOrderLineNum { get; set; }


        /// <summary>
        /// 外部商品编号
        /// </summary>
        [XmlElement("SkuNo")]
        public string SkuNo { get; set; }


        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("ProductName")]
        public string ProductName { get; set; }


        /// <summary>
        /// 实发数量
        /// </summary>
        [XmlElement("ActualQty")]
        public Nullable<int> ActualQty { get; set; }


        /// <summary>
        /// 单位
        /// </summary>
        [XmlElement("QtyUm")]
        public string QtyUm { get; set; }


        /// <summary>
        /// 批号属性1
        /// </summary>
        [XmlElement("LotAttr1")]
        public string LotAttr1 { get; set; }


        /// <summary>
        /// 批号属性2
        /// </summary>
        [XmlElement("LotAttr2")]
        public string LotAttr2 { get; set; }


        /// <summary>
        /// 批号属性3
        /// </summary>
        [XmlElement("LotAttr3")]
        public string LotAttr3 { get; set; }


        /// <summary>
        /// 批号属性4
        /// </summary>
        [XmlElement("LotAttr4")]
        public string LotAttr4 { get; set; }


        /// <summary>
        /// 批号属性5
        /// </summary>
        [XmlElement("LotAttr5")]
        public string LotAttr5 { get; set; }


        /// <summary>
        /// 批号属性6
        /// </summary>
        [XmlElement("LotAttr6")]
        public string LotAttr6 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef1")]
        public string UserDef1 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef2")]
        public string UserDef2 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef3")]
        public string UserDef3 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef4")]
        public string UserDef4 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef5")]
        public string UserDef5 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef6")]
        public string UserDef6 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef7")]
        public string UserDef7 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef8")]
        public string UserDef8 { get; set; }


    }


    /// <summary>
    /// 包裹信息
    /// </summary>
    [Serializable]
    public class OrderPackageDetail
    {
        /// <summary>
        /// 箱号（运单号）
        /// </summary>
        [XmlElement("ContainerNo")]
        public string ContainerNo { get; set; }


        /// <summary>
        /// 子母件标识1-子件 0:母件
        /// </summary>
        [XmlElement("ContainerType")]
        public Nullable<int> ContainerType { get; set; }

        /// <summary>
        /// 净量
        /// </summary>
        [XmlElement("Weight")]
        public Nullable<decimal> Weight { get; set; }


        /// <summary>
        /// 重量单位
        /// </summary>
        [XmlElement("WeightUm")]
        public string WeightUm { get; set; }


        /// <summary>
        /// 包装员
        /// </summary>
        [XmlElement("UserStamp")]
        public string UserStamp { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef1")]
        public string UserDef1 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef2")]
        public string UserDef2 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef3")]
        public string UserDef3 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef4")]
        public string UserDef4 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef5")]
        public string UserDef5 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef6")]
        public string UserDef6 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef7")]
        public string UserDef7 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef8")]
        public string UserDef8 { get; set; }


        [XmlArray("ContainerItems")]
        [XmlArrayItem("Item")]
        public List<ContainerItem> ContainerItems { get; set; }

    }


    /// <summary>
    /// 包裹商品明细
    /// </summary>
    public class ContainerItem
    {

        /// <summary>
        /// 货品编码
        /// </summary>
        [XmlElement("SkuNo")]
        public string SkuNo { get; set; }


        /// <summary>
        /// 数量
        /// </summary>
        [XmlElement("ActualQty")]
        public Nullable<int> ActualQty { get; set; }


        /// <summary>
        /// 单位
        /// </summary>
        [XmlElement("QtyUm")]
        public string QtyUm { get; set; }


        /// <summary>
        /// 净量
        /// </summary>
        [XmlElement("Weight")]
        public Nullable<decimal> Weight { get; set; }


        /// <summary>
        /// 重量单位
        /// </summary>
        [XmlElement("WeightUm")]
        public string WeightUm { get; set; }


        /// <summary>
        /// 批号
        /// </summary>
        [XmlElement("Lot")]
        public string Lot { get; set; }


        /// <summary>
        /// 库存状态
        ///10:正品
        ///20:残品
        /// </summary>
        [XmlElement("InventoryStatus")]
        public string InventoryStatus { get; set; }

        
        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef1")]
        public string UserDef1 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef2")]
        public string UserDef2 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef3")]
        public string UserDef3 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef4")]
        public string UserDef4 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef5")]
        public string UserDef5 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef6")]
        public string UserDef6 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef7")]
        public string UserDef7 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef8")]
        public string UserDef8 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef9")]
        public string UserDef9 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef10")]
        public string UserDef10 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef11")]
        public string UserDef11 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef12")]
        public string UserDef12 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef13")]
        public string UserDef13 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef14")]
        public string UserDef14 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef15")]
        public string UserDef15 { get; set; }



        /// <summary>
        /// 预留字段
        /// </summary>
        [XmlElement("UserDef16")]
        public string UserDef16 { get; set; }



        [XmlElement("SerialNumbers")]
        public SerialNumbers SerialNumbers { get; set; }
    }

    [Serializable]
    public class SerialNumbers
    {
        /// <summary>
        /// 序列号
        /// </summary>
        [XmlElement("SerialNumber")]
        public string SerialNumber { get; set; }
    }

}
