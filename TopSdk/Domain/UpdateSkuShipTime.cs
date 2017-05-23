using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// UpdateSkuShipTime Data Structure.
    /// </summary>
    [Serializable]
    public class UpdateSkuShipTime : TopObject
    {
        /// <summary>
        /// Sku的商家外部id；如：2015_07_23_D_123
        /// </summary>
        [XmlElement("outer_id")]
        public string OuterId { get; set; }

        /// <summary>
        /// Sku属性串。格式:pid:vid;pid:vid,如: 1627207:3232483;1630696:3284570,表示机身颜色:军绿色;手机套餐:一电一充
        /// </summary>
        [XmlElement("properties")]
        public string Properties { get; set; }

        /// <summary>
        /// 被更新发货时间；格式和具体设置的发货时间格式相关。绝对发货时间填写yyyy-MM-dd;相对发货时间填写数字
        /// </summary>
        [XmlElement("ship_time")]
        public string ShipTime { get; set; }

        /// <summary>
        /// SKU的ID
        /// </summary>
        [XmlElement("sku_id")]
        public long SkuId { get; set; }
    }
}
