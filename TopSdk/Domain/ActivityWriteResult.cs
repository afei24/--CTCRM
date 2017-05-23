using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ActivityWriteResult Data Structure.
    /// </summary>
    [Serializable]
    public class ActivityWriteResult : TopObject
    {
        /// <summary>
        /// 报名成功的id
        /// </summary>
        [XmlElement("activity_id")]
        public long ActivityId { get; set; }

        /// <summary>
        /// 活动页面h5链接
        /// </summary>
        [XmlElement("h5_url")]
        public string H5Url { get; set; }
    }
}
