using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoReturnBillReturnorderinfo Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoReturnBillReturnorderinfo : TopObject
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
        /// 订单商品信息列表
        /// </summary>
        [XmlArray("order_item_list")]
        [XmlArrayItem("cainiao_return_bill_orderitemlist")]
        public List<Top.Api.Domain.CainiaoReturnBillOrderitemlist> OrderItemList { get; set; }

        /// <summary>
        /// 单据类型： 501 退货入库
        /// </summary>
        [XmlElement("order_type")]
        public long OrderType { get; set; }

        /// <summary>
        /// 此销退订单对应原销售订单的菜鸟订单号
        /// </summary>
        [XmlElement("pre_cn_order_code")]
        public string PreCnOrderCode { get; set; }
    }
}
