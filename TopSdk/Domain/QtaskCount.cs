using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// QtaskCount Data Structure.
    /// </summary>
    [Serializable]
    public class QtaskCount : TopObject
    {
        /// <summary>
        /// 未完成的会员任务
        /// </summary>
        [XmlElement("member")]
        public long Member { get; set; }

        /// <summary>
        /// 需要提醒的任务
        /// </summary>
        [XmlElement("remind")]
        public long Remind { get; set; }

        /// <summary>
        /// 未完成的交易任务
        /// </summary>
        [XmlElement("trade")]
        public long Trade { get; set; }

        /// <summary>
        /// 未完成的发起的任务
        /// </summary>
        [XmlElement("wait_for_other")]
        public long WaitForOther { get; set; }

        /// <summary>
        /// 未完成的收到的任务
        /// </summary>
        [XmlElement("wait_for_self")]
        public long WaitForSelf { get; set; }
    }
}
