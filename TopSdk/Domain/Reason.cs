using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Reason Data Structure.
    /// </summary>
    [Serializable]
    public class Reason : TopObject
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("reason_id")]
        public long ReasonId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("reason_text")]
        public string ReasonText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("reason_tips")]
        public string ReasonTips { get; set; }
    }
}
