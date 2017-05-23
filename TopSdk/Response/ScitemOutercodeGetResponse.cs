using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ScitemOutercodeGetResponse.
    /// </summary>
    public class ScitemOutercodeGetResponse : TopResponse
    {
        /// <summary>
        /// 后台商品
        /// </summary>
        [XmlElement("sc_item")]
        public Top.Api.Domain.ScItem ScItem { get; set; }

    }
}
