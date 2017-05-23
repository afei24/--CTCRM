using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoConsignOutstockOutstockinfo Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoConsignOutstockOutstockinfo : TopObject
    {
        /// <summary>
        /// 菜鸟订单编码
        /// </summary>
        [XmlElement("cn_order_code")]
        public string CnOrderCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlElement("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// ERP订单编码
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单列表
        /// </summary>
        [XmlArray("order_item_list")]
        [XmlArrayItem("cainiao_consign_outstock_orderitemlist")]
        public List<Top.Api.Domain.CainiaoConsignOutstockOrderitemlist> OrderItemList { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }
    }
}
