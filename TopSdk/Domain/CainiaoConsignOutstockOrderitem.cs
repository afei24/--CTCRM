using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CainiaoConsignOutstockOrderitem Data Structure.
    /// </summary>
    [Serializable]
    public class CainiaoConsignOutstockOrderitem : TopObject
    {
        /// <summary>
        /// 商家对商品的编码
        /// </summary>
        [XmlElement("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 应发商品数量
        /// </summary>
        [XmlElement("item_qty")]
        public long ItemQty { get; set; }

        /// <summary>
        /// 商品缺货数量
        /// </summary>
        [XmlElement("lack_qty")]
        public long LackQty { get; set; }

        /// <summary>
        /// 失败原因（系统报缺，实物报缺)
        /// </summary>
        [XmlElement("reason")]
        public string Reason { get; set; }
    }
}
