using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// SycmDashboardLowGetResponse.
    /// </summary>
    public class SycmDashboardLowGetResponse : TopResponse
    {
        /// <summary>
        /// 为千牛数字面板提供数据
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.DashboardRealtimeLowBO Result { get; set; }

    }
}
