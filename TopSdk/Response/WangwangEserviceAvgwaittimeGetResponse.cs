using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WangwangEserviceAvgwaittimeGetResponse.
    /// </summary>
    public class WangwangEserviceAvgwaittimeGetResponse : TopResponse
    {
        /// <summary>
        /// 平均等待时长
        /// </summary>
        [XmlArray("waiting_time_list_on_days")]
        [XmlArrayItem("waiting_times_on_day")]
        public List<Top.Api.Domain.WaitingTimesOnDay> WaitingTimeListOnDays { get; set; }

    }
}
