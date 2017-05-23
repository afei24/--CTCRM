using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoInventoryProfitlossProfitlossinfo Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoInventoryProfitlossProfitlossinfo : TopObject
    {
        /// <summary>
        /// 仓库订单编码
        /// </summary>
        [XmlElement("cn_order_code")]
        public string CnOrderCode { get; set; }

        /// <summary>
        /// 单据生成时间
        /// </summary>
        [XmlElement("created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// 商品信息列表
        /// </summary>
        [XmlArray("order_item_list")]
        [XmlArrayItem("cainiao_inventory_profitloss_orderitemlist")]
        public List<Top.Api.Domain.CainiaoInventoryProfitlossOrderitemlist> OrderItemList { get; set; }

        /// <summary>
        /// 订单类型： 701 盘点出库 702 盘点入库
        /// </summary>
        [XmlElement("order_type")]
        public long OrderType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }
    }
}
