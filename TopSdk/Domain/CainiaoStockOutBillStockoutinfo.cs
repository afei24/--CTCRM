using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockOutBillStockoutinfo Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockOutBillStockoutinfo : TopObject
    {
        /// <summary>
        /// 仓库订单编码，LBX号
        /// </summary>
        [XmlElement("cn_order_code")]
        public string CnOrderCode { get; set; }

        /// <summary>
        /// 仓库订单完成时间
        /// </summary>
        [XmlElement("confirm_time")]
        public string ConfirmTime { get; set; }

        /// <summary>
        /// ERP订单号
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单商品列表
        /// </summary>
        [XmlArray("order_item_list")]
        [XmlArrayItem("cainiao_stock_out_bill_orderitemlist")]
        public List<Top.Api.Domain.CainiaoStockOutBillOrderitemlist> OrderItemList { get; set; }

        /// <summary>
        /// 单据类型 903 普通出库单 305 B2B出库单 901 退供出库单
        /// </summary>
        [XmlElement("order_type")]
        public long OrderType { get; set; }

        /// <summary>
        /// 包裹信息列表，包含每个包裹使用的快递信息
        /// </summary>
        [XmlArray("package_info_list")]
        [XmlArrayItem("cainiao_stock_out_bill_packageinfolist")]
        public List<Top.Api.Domain.CainiaoStockOutBillPackageinfolist> PackageInfoList { get; set; }

        /// <summary>
        /// 入库单状态
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
