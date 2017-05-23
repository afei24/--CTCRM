using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// EcloudTopSysfileAddResponse.
    /// </summary>
    public class EcloudTopSysfileAddResponse : TopResponse
    {
        /// <summary>
        /// 返回多个结果
        /// </summary>
        [XmlElement("ecloud_result")]
        public Top.Api.Domain.EcloudListFileEntityResult EcloudResult { get; set; }

    }
}
