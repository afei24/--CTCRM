using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// InteractGamePoint Data Structure.
    /// </summary>
    [Serializable]
    public class InteractGamePoint : TopObject
    {
        /// <summary>
        /// 最大分数
        /// </summary>
        [XmlElement("max_point")]
        public long MaxPoint { get; set; }

        /// <summary>
        /// 最小分数
        /// </summary>
        [XmlElement("min_point")]
        public long MinPoint { get; set; }
    }
}
