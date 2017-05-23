using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// PushResult Data Structure.
    /// </summary>
    [Serializable]
    public class PushResult : TopObject
    {
        /// <summary>
        /// 新广播ID
        /// </summary>
        [XmlElement("feed_id")]
        public string FeedId { get; set; }
    }
}
