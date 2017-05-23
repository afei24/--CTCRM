using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// UpdateSkuOuterId Data Structure.
    /// </summary>
    [Serializable]
    public class UpdateSkuOuterId : TopObject
    {
        /// <summary>
        /// 被更新的Sku的商家外部id；如果清空，传空串
        /// </summary>
        [XmlElement("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// Sku属性串。格式:pid:vid;pid:vid,如: 1627207:3232483;1630696:3284570,表示机身颜色:军绿色;手机套餐:一电一充
        /// </summary>
        [XmlElement("properties")]
        public string Properties { get; set; }

        /// <summary>
        /// SKU的ID
        /// </summary>
        [XmlElement("sku_id")]
        public Nullable<long> SkuId { get; set; }
    }
}
