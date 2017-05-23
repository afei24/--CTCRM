using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// SkusDeliveryTime Data Structure.
    /// </summary>
    [Serializable]
    public class SkusDeliveryTime : TopObject
    {
        /// <summary>
        /// sku时间
        /// </summary>
        [XmlElement("sku_delivery_time")]
        public string SkuDeliveryTime { get; set; }

        /// <summary>
        /// 商品skuId
        /// </summary>
        [XmlElement("sku_id")]
        public long SkuId { get; set; }
    }
}
