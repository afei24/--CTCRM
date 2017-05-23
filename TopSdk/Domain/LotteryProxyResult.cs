using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// LotteryProxyResult Data Structure.
    /// </summary>
    [Serializable]
    public class LotteryProxyResult : TopObject
    {
        /// <summary>
        /// 奖品id
        /// </summary>
        [XmlElement("award_id")]
        public long AwardId { get; set; }

        /// <summary>
        /// 奖品名称
        /// </summary>
        [XmlElement("award_name")]
        public string AwardName { get; set; }

        /// <summary>
        /// 奖品类型
        /// </summary>
        [XmlElement("award_type")]
        public string AwardType { get; set; }

        /// <summary>
        /// 扩展字段1
        /// </summary>
        [XmlElement("ext_value1")]
        public string ExtValue1 { get; set; }

        /// <summary>
        /// 扩展字段2
        /// </summary>
        [XmlElement("ext_value2")]
        public string ExtValue2 { get; set; }

        /// <summary>
        /// 扩展字段3
        /// </summary>
        [XmlElement("ext_value3")]
        public string ExtValue3 { get; set; }

        /// <summary>
        /// 扩展字段4
        /// </summary>
        [XmlElement("ext_value4")]
        public string ExtValue4 { get; set; }

        /// <summary>
        /// 扩展字段5
        /// </summary>
        [XmlElement("ext_value5")]
        public string ExtValue5 { get; set; }

        /// <summary>
        /// 奖品拓展字段
        /// </summary>
        [XmlElement("extra")]
        public string Extra { get; set; }

        /// <summary>
        /// 奖品组id
        /// </summary>
        [XmlElement("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 是否中奖
        /// </summary>
        [XmlElement("is_win")]
        public bool IsWin { get; set; }

        /// <summary>
        /// 抽奖id
        /// </summary>
        [XmlElement("lottery_id")]
        public long LotteryId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        [XmlElement("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [XmlElement("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 中奖记录id
        /// </summary>
        [XmlElement("winning_record_id")]
        public long WinningRecordId { get; set; }

        /// <summary>
        /// 中奖时间
        /// </summary>
        [XmlElement("winning_time")]
        public string WinningTime { get; set; }
    }
}
