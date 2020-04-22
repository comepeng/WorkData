﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Compeng.OMS.BusinessModel.InterfaceModels.EMS.Request
{
    /// <summary>
    /// 将详情单打印信息更新到自助服务系统
    /// </summary>
    [Serializable]
    [XmlRoot("XMLInfo")]
    public class EMSUpdatePrintDatasReq
    {
        /// <summary>
        /// 账号（大客户号）
        /// </summary>
        [XmlElement("sysAccount")]
        public string SysAccount { get; set; }

        /// <summary>
        /// 密码（对接密码）
        /// </summary>
        [XmlElement("passWord")]
        public string PassWord { get; set; }

        /// <summary>
        /// 数据类型，1:预制详情单；2:热敏标签式详情单
        /// </summary>
        [XmlElement("printKind")]
        public string PrintKind { get; set; }

        /// <summary>
        /// 对接授权码
        /// </summary>
        [XmlElement("appKey")]
        public string AppKey { get; set; }

        /// <summary>
        /// 邮件数据结构
        /// </summary>
        [XmlArray("printDatas")]
        [XmlArrayItem("printData")]
        public List<EMSPrintData> OrderPrintDataList { get; set; }
    }

    /// <summary>
    /// 订单数据信息
    /// </summary>
    public class EMSPrintData
    {
        /// <summary>
        /// 邮件数据唯一标识,邮件数据的主键
        /// </summary>
        [XmlElement("bigAccountDataId")]
        public string BigAccountDataId { get; set; }

        /// <summary>
        /// 业务类型,1:标准快递;9:快递包裹
        /// </summary>
        [XmlElement("businessType")]
        public string BusinessType { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        [XmlElement("billno")]
        public string Billno { get; set; }

        /// <summary>
        /// 时间类型,1:收寄时间;2:打印时间
        /// </summary>
        [XmlElement("dateType")]
        public string DateType { get; set; }

        /// <summary>
        /// 时间,YYYY-MM-DD hh:mi:ss
        /// </summary>
        [XmlElement("procdate")]
        public string Procdate { get; set; }

        /// <summary>
        /// 寄件人姓名
        /// </summary>
        [XmlElement("scontactor")]
        public string Scontactor { get; set; }

        /// <summary>
        /// 寄件人电话1
        /// </summary>
        [XmlElement("scustMobile")]
        public string ScustMobile { get; set; }

        /// <summary>
        /// 寄件人电话2
        /// </summary>
        [XmlElement("scustTelplus")]
        public string ScustTelplus { get; set; }

        /// <summary>
        /// 寄件人邮编
        /// </summary>
        [XmlElement("scustPost")]
        public string ScustPost { get; set; }

        /// <summary>
        /// 寄件人地址
        /// </summary>
        [XmlElement("scustAddr")]
        public string ScustAddr { get; set; }

        /// <summary>
        /// 寄件人公司名称
        /// </summary>
        [XmlElement("scustComp")]
        public string ScustComp { get; set; }

        /// <summary>
        /// 寄件人所在省
        /// </summary>
        [XmlElement("scustProvince")]
        public string ScustProvince { get; set; }

        /// <summary>
        /// 寄件人所在市
        /// </summary>
        [XmlElement("scustCity")]
        public string ScustCity { get; set; }

        /// <summary>
        /// 寄件人所在区县
        /// </summary>
        [XmlElement("scustCounty")]
        public string ScustCounty { get; set; }

        /// <summary>
        /// 收件人姓名
        /// </summary>
        [XmlElement("tcontactor")]
        public string Tcontactor { get; set; }

        /// <summary>
        /// 收件人电话1
        /// </summary>
        [XmlElement("tcustMobile")]
        public string TcustMobile { get; set; }

        /// <summary>
        /// 收件人电话2
        /// </summary>
        [XmlElement("tcustTelplus")]
        public string TcustTelplus { get; set; }

        /// <summary>
        ///收件人邮编
        /// </summary>
        [XmlElement("tcustPost")]
        public string TcustPost { get; set; }

        /// <summary>
        /// 收件人地址
        /// </summary>
        [XmlElement("tcustAddr")]
        public string TcustAddr { get; set; }

        /// <summary>
        /// 收件人公司名称
        /// </summary>
        [XmlElement("tcustComp")]
        public string TcustComp { get; set; }

        /// <summary>
        /// 收件人所在省
        /// </summary>
        [XmlElement("tcustProvince")]
        public string TcustProvince { get; set; }

        /// <summary>
        /// 收件人所在市
        /// </summary>
        [XmlElement("tcustCity")]
        public string TcustCity { get; set; }

        /// <summary>
        /// 收件人所在区县
        /// </summary>
        [XmlElement("tcustCounty")]
        public string TcustCounty { get; set; }

        /// <summary>
        /// 货物重量，单位：KG
        /// </summary>
        [XmlElement("weight")]
        public decimal? Weight { get; set; }

        /// <summary>
        /// 货物长度，单位：CM
        /// </summary>
        [XmlElement("length")]
        public decimal? Length { get; set; }

        /// <summary>
        /// 货物宽度，单位：CM
        /// </summary>
        [XmlElement("wtdth")]
        public decimal? Wtdth { get; set; }

        /// <summary>
        /// 货物高度，单位：CM
        /// </summary>
        [XmlElement("height")]
        public decimal? Height { get; set; }

        /// <summary>
        /// 保价金额，单位：元
        /// </summary>
        [XmlElement("insure")]
        public decimal? Insure { get; set; }

        /// <summary>
        /// 保险金额，单位：元
        /// </summary>
        [XmlElement("insurance")]
        public decimal? Insurance { get; set; }

        /// <summary>
        /// 货款金额，单位：元
        /// </summary>
        [XmlElement("fee")]
        public decimal? Fee { get; set; }

        /// <summary>
        /// 大写货款金额
        /// </summary>
        [XmlElement("feeUppercase")]
        public string FeeUppercase { get; set; }

        /// <summary>
        /// 内件信息
        /// </summary>
        [XmlElement("cargoDesc")]
        public string CargoDesc { get; set; }

        /// <summary>
        /// 内件类型，传入文字：文件，物品
        /// </summary>
        [XmlElement("cargoType")]
        public string CargoType { get; set; }

        /// <summary>
        /// 揽投员的投递要求
        /// </summary>
        [XmlElement("deliveryclaim")]
        public string Deliveryclaim { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// EMS内部定义的邮件产品代码
        /// </summary>
        [XmlElement("productCode")]
        public string ProductCode { get; set; }

        /// <summary>
        /// 一票多件必填
        /// </summary>
        [XmlElement("customerDn")]
        public string CustomerDn { get; set; }

        /// <summary>
        /// 分单数
        /// </summary>
        [XmlElement("subBillCount")]
        public int? SubBillCount { get; set; }

        /// <summary>
        /// 主单邮件号，分单对应的主单邮件号；主单邮件和普通邮件，该字段放空
        /// </summary>
        [XmlElement("mainBillNo")]
        public string MainBillNo { get; set; }

        /// <summary>
        /// 主分单标识，1：普通(无分单时)；2：主单；3：分单
        /// </summary>
        [XmlElement("mainBillFlag")]
        public string MainBillFlag { get; set; }

        /// <summary>
        /// 一票多单计费方式，1：集中主单计费；2：平均重量计费；3：分单免首重；4：主分单单独计费
        /// </summary>
        [XmlElement("mainSubPayMode")]
        public string MainSubPayMode { get; set; }

        /// <summary>
        /// 付费类型，1：现金(支票)；2：记欠；3：托收；4：转帐；9：其他
        /// </summary>
        [XmlElement("payMode")]
        public string PayMode { get; set; }

        /// <summary>
        /// 所负责任,2：保价;3：保险
        /// </summary>
        [XmlElement("insureType")]
        public string InsureType { get; set; }

        /// <summary>
        /// 代收货款（附加服务）,1:代收货款;0:非代收货款
        /// </summary>
        [XmlElement("addser_dshk")]
        public string Addser_dshk { get; set; }

        /// <summary>
        /// 收件人付费(附加服务),1:收件人付费;0:非收件人付费
        /// </summary>
        [XmlElement("addser_sjrff")]
        public string Addser_sjrff { get; set; }

        /// <summary>
        /// 留白1
        /// </summary>
        [XmlElement("blank1")]
        public string Blank1 { get; set; }

        /// <summary>
        /// 留白2
        /// </summary>
        [XmlElement("blank2")]
        public string Blank2 { get; set; }
    }
}
