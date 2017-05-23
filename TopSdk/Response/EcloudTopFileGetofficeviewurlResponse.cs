using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// EcloudTopFileGetofficeviewurlResponse.
    /// </summary>
    public class EcloudTopFileGetofficeviewurlResponse : TopResponse
    {
        /// <summary>
        /// 返回值
        /// </summary>
        [XmlElement("ecloud_result")]
        public Top.Api.Domain.EcloudStringResult EcloudResult { get; set; }

    }
}
