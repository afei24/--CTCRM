using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// OrderItemswlbwmsstockinorderconfirm Data Structure.
    /// </summary>
    [Serializable]
    public class OrderItemswlbwmsstockinorderconfirm : TopObject
    {
        /// <summary>
        /// 是否完成
        /// </summary>
        [XmlElement("is_completed")]
        public Nullable<bool> IsCompleted { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        [XmlElement("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 商品列表
        /// </summary>
        [XmlArray("items")]
        [XmlArrayItem("itemswlbwmsstockinorderconfirmwl")]
        public List<Top.Api.Domain.Itemswlbwmsstockinorderconfirmwl> Items { get; set; }

        /// <summary>
        /// ERP入库单子ID
        /// </summary>
        [XmlElement("order_item_id")]
        public string OrderItemId { get; set; }
    }
}
