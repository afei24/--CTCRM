using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// EcloudTopFileGetjangocodeResponse.
    /// </summary>
    public class EcloudTopFileGetjangocodeResponse : TopResponse
    {
        /// <summary>
        /// 获取 Jango code返回结果
        /// </summary>
        [XmlElement("ecloud_result")]
        public Top.Api.Domain.EcloudJangoCodeResult EcloudResult { get; set; }

    }
}
