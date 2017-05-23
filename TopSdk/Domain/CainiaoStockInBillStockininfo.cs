using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoStockInBillStockininfo Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoStockInBillStockininfo : TopObject
    {
        /// <summary>
        /// 菜鸟订单编码
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
        /// 入库单信息
        /// </summary>
        [XmlArray("order_item_list")]
        [XmlArrayItem("cainiao_stock_in_bill_orderitemlist")]
        public List<Top.Api.Domain.CainiaoStockInBillOrderitemlist> OrderItemList { get; set; }

        /// <summary>
        /// 单据类型：  904 普通入库 306 B2B入库单 601 采购入库
        /// </summary>
        [XmlElement("order_type")]
        public long OrderType { get; set; }

        /// <summary>
        /// 入库单状态 WMS_ACCEPT 接单成功 WMS_REJECT 接单失败WMS_CONFIRMED 仓库生产完成
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
