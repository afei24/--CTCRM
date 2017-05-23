using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallInteractIsvlotteryDrawResponse.
    /// </summary>
    public class TmallInteractIsvlotteryDrawResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public CommonResultDomain Result { get; set; }

	/// <summary>
/// LotteryProxyResultDomain Data Structure.
/// </summary>
[Serializable]
public class LotteryProxyResultDomain : TopObject
{
	        /// <summary>
	        /// awardId
	        /// </summary>
	        [XmlElement("award_id")]
	        public long AwardId { get; set; }
	
	        /// <summary>
	        /// awardName
	        /// </summary>
	        [XmlElement("award_name")]
	        public string AwardName { get; set; }
	
	        /// <summary>
	        /// awardType
	        /// </summary>
	        [XmlElement("award_type")]
	        public string AwardType { get; set; }
	
	        /// <summary>
	        /// extValue1
	        /// </summary>
	        [XmlElement("ext_value1")]
	        public string ExtValue1 { get; set; }
	
	        /// <summary>
	        /// extValue2
	        /// </summary>
	        [XmlElement("ext_value2")]
	        public string ExtValue2 { get; set; }
	
	        /// <summary>
	        /// extValue3
	        /// </summary>
	        [XmlElement("ext_value3")]
	        public string ExtValue3 { get; set; }
	
	        /// <summary>
	        /// extValue4
	        /// </summary>
	        [XmlElement("ext_value4")]
	        public string ExtValue4 { get; set; }
	
	        /// <summary>
	        /// extValue5
	        /// </summary>
	        [XmlElement("ext_value5")]
	        public string ExtValue5 { get; set; }
	
	        /// <summary>
	        /// extra
	        /// </summary>
	        [XmlElement("extra")]
	        public string Extra { get; set; }
	
	        /// <summary>
	        /// groupId
	        /// </summary>
	        [XmlElement("group_id")]
	        public long GroupId { get; set; }
	
	        /// <summary>
	        /// isWin
	        /// </summary>
	        [XmlElement("is_win")]
	        public bool IsWin { get; set; }
	
	        /// <summary>
	        /// lotteryId
	        /// </summary>
	        [XmlElement("lottery_id")]
	        public long LotteryId { get; set; }
	
	        /// <summary>
	        /// nick
	        /// </summary>
	        [XmlElement("nick")]
	        public string Nick { get; set; }
	
	        /// <summary>
	        /// reason
	        /// </summary>
	        [XmlElement("reason")]
	        public string Reason { get; set; }
	
	        /// <summary>
	        /// userId
	        /// </summary>
	        [XmlElement("user_id")]
	        public long UserId { get; set; }
	
	        /// <summary>
	        /// winningRecordId
	        /// </summary>
	        [XmlElement("winning_record_id")]
	        public long WinningRecordId { get; set; }
	
	        /// <summary>
	        /// winningTime
	        /// </summary>
	        [XmlElement("winning_time")]
	        public string WinningTime { get; set; }
}

	/// <summary>
/// CommonResultDomain Data Structure.
/// </summary>
[Serializable]
public class CommonResultDomain : TopObject
{
	        /// <summary>
	        /// code
	        /// </summary>
	        [XmlElement("code")]
	        public string Code { get; set; }
	
	        /// <summary>
	        /// data
	        /// </summary>
	        [XmlElement("data")]
	        public LotteryProxyResultDomain Data { get; set; }
	
	        /// <summary>
	        /// msg
	        /// </summary>
	        [XmlElement("msg")]
	        public string Msg { get; set; }
	
	        /// <summary>
	        /// succ
	        /// </summary>
	        [XmlElement("succ")]
	        public bool Succ { get; set; }
}

    }
}
