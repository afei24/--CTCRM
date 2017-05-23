using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// PrizePondDTO Data Structure.
    /// </summary>
    [Serializable]
    public class PrizePondDTO : TopObject
    {
        /// <summary>
        /// 奖品列表
        /// </summary>
        [XmlArray("award_beans")]
        [XmlArrayItem("award_bean")]
        public List<Top.Api.Domain.AwardBean> AwardBeans { get; set; }

        /// <summary>
        /// 奖池结束时间
        /// </summary>
        [XmlElement("end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// 奖池ID
        /// </summary>
        [XmlElement("lottery_code")]
        public string LotteryCode { get; set; }

        /// <summary>
        /// 抽奖名称
        /// </summary>
        [XmlElement("lottery_name")]
        public string LotteryName { get; set; }

        /// <summary>
        /// 奖池开始时间
        /// </summary>
        [XmlElement("start_time")]
        public string StartTime { get; set; }
    }
}
