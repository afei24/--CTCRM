using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// EcloudTopFileGetdownloadurlResponse.
    /// </summary>
    public class EcloudTopFileGetdownloadurlResponse : TopResponse
    {
        /// <summary>
        /// 下载地址
        /// </summary>
        [XmlElement("ecloud_result")]
        public Top.Api.Domain.EcloudStringResult EcloudResult { get; set; }

    }
}
