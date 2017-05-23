using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// AwardBean Data Structure.
    /// </summary>
    [Serializable]
    public class AwardBean : TopObject
    {
        /// <summary>
        /// 奖品Id
        /// </summary>
        [XmlElement("award_id")]
        public long AwardId { get; set; }

        /// <summary>
        /// 奖品名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 奖品类型
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
