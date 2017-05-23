using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// EcloudTopFileGetResponse.
    /// </summary>
    public class EcloudTopFileGetResponse : TopResponse
    {
        /// <summary>
        /// 淘盘单个文件详情
        /// </summary>
        [XmlElement("ecloud_result")]
        public Top.Api.Domain.EcloudFileEntityResult EcloudResult { get; set; }

    }
}
