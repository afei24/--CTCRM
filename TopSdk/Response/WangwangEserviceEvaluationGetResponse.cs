using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WangwangEserviceEvaluationGetResponse.
    /// </summary>
    public class WangwangEserviceEvaluationGetResponse : TopResponse
    {
        /// <summary>
        /// 客服平均统计列表
        /// </summary>
        [XmlArray("staff_eval_stat_on_days")]
        [XmlArrayItem("staff_eval_stat_on_day")]
        public List<Top.Api.Domain.StaffEvalStatOnDay> StaffEvalStatOnDays { get; set; }

    }
}
