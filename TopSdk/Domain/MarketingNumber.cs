using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// MarketingNumber Data Structure.
    /// </summary>
    [Serializable]
    public class MarketingNumber : TopObject
    {
        /// <summary>
        /// 满就送活动数量
        /// </summary>
        [XmlElement("mjs_num")]
        public long MjsNum { get; set; }

        /// <summary>
        /// 满减折活动数量
        /// </summary>
        [XmlElement("mjz_num")]
        public long MjzNum { get; set; }

        /// <summary>
        /// 商家营销活动总数量
        /// </summary>
        [XmlElement("total_num")]
        public long TotalNum { get; set; }

        /// <summary>
        /// 限时打折活动数量
        /// </summary>
        [XmlElement("xsdz_num")]
        public long XsdzNum { get; set; }
    }
}
