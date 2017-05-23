using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// HealthcenterCountfortopQueryResponse.
    /// </summary>
    public class HealthcenterCountfortopQueryResponse : TopResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [XmlElement("result")]
        public HealthCountDoDomain Result { get; set; }

	/// <summary>
/// HealthCountDoDomain Data Structure.
/// </summary>
[Serializable]
public class HealthCountDoDomain : TopObject
{
	        /// <summary>
	        /// 历史管控数量
	        /// </summary>
	        [XmlElement("history_market_manager_count")]
	        public long HistoryMarketManagerCount { get; set; }
	
	        /// <summary>
	        /// 历史处罚数量
	        /// </summary>
	        [XmlElement("history_punish_count")]
	        public long HistoryPunishCount { get; set; }
	
	        /// <summary>
	        /// 待处理违规数量
	        /// </summary>
	        [XmlElement("pending_count")]
	        public long PendingCount { get; set; }
	
	        /// <summary>
	        /// 待处理管控数量
	        /// </summary>
	        [XmlElement("pending_market_manager_count")]
	        public long PendingMarketManagerCount { get; set; }
}

    }
}
