using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractActivityUnregisterResponse.
    /// </summary>
    public class AlibabaInteractActivityUnregisterResponse : TopResponse
    {
        /// <summary>
        /// 关闭活动结果
        /// </summary>
        [XmlElement("unregister_result")]
        public Top.Api.Domain.AllsparkResult UnregisterResult { get; set; }

    }
}
