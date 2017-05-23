using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// EcloudTopSysfileListResponse.
    /// </summary>
    public class EcloudTopSysfileListResponse : TopResponse
    {
        /// <summary>
        /// 文件list详情信息
        /// </summary>
        [XmlElement("ecloud_result")]
        public Top.Api.Domain.EcloudListPageFileEntityResult EcloudResult { get; set; }

    }
}
