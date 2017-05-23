using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// WlbWmsInventoryLackUpload Data Structure.
    /// </summary>
    [Serializable]
    public class WlbWmsInventoryLackUpload : TopObject
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlElement("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 商品信息列表
        /// </summary>
        [XmlArray("item_list")]
        [XmlArrayItem("item_list_wlb_wms_inventory_lack_upload")]
        public List<Top.Api.Domain.ItemListWlbWmsInventoryLackUpload> ItemList { get; set; }

        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 外部业务编码;消息ID，用于去重
        /// </summary>
        [XmlElement("out_biz_code")]
        public string OutBizCode { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }

        /// <summary>
        /// 仓储订单编码
        /// </summary>
        [XmlElement("store_order_code")]
        public string StoreOrderCode { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [XmlElement("strore_code")]
        public string StroreCode { get; set; }
    }
}
