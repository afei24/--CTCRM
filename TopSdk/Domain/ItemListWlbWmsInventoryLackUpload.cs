using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ItemListWlbWmsInventoryLackUpload Data Structure.
    /// </summary>
    [Serializable]
    public class ItemListWlbWmsInventoryLackUpload : TopObject
    {
        /// <summary>
        /// 后端商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 应发商品数量
        /// </summary>
        [XmlElement("item_qty")]
        public Nullable<long> ItemQty { get; set; }

        /// <summary>
        /// 商品缺货数量
        /// </summary>
        [XmlElement("lack_qty")]
        public Nullable<long> LackQty { get; set; }

        /// <summary>
        /// 报缺原因（系统报缺，实物报缺）
        /// </summary>
        [XmlElement("reason")]
        public string Reason { get; set; }
    }
}
