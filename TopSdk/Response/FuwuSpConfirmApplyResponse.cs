using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FuwuSpConfirmApplyResponse.
    /// </summary>
    public class FuwuSpConfirmApplyResponse : TopResponse
    {
        /// <summary>
        /// 返回的是服务市场的确认单ID
        /// </summary>
        [XmlElement("apply_result")]
        public long ApplyResult { get; set; }

    }
}
