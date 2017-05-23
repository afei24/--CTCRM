using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbInventoryDetailGetResponse.
    /// </summary>
    public class WlbInventoryDetailGetResponse : TopResponse
    {
        /// <summary>
        /// 库存详情对象。其中包括货主ID，仓库编码，库存，库存类型等属性
        /// </summary>
        [XmlArray("inventory_list")]
        [XmlArrayItem("wlb_inventory")]
        public List<Top.Api.Domain.WlbInventory> InventoryList { get; set; }

        /// <summary>
        /// 入参的item_id
        /// </summary>
        [XmlElement("item_id")]
        public long ItemId { get; set; }

    }
}
