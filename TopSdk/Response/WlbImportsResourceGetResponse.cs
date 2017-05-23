using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbImportsResourceGetResponse.
    /// </summary>
    public class WlbImportsResourceGetResponse : TopResponse
    {
        /// <summary>
        /// 一般进口所有服务商列表
        /// </summary>
        [XmlArray("resources")]
        [XmlArrayItem("resource_result")]
        public List<Top.Api.Domain.ResourceResult> Resources { get; set; }

    }
}
