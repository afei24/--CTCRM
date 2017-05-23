using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ScitemGetResponse.
    /// </summary>
    public class ScitemGetResponse : TopResponse
    {
        /// <summary>
        /// 后端商品
        /// </summary>
        [XmlElement("sc_item")]
        public Top.Api.Domain.ScItem ScItem { get; set; }

    }
}
