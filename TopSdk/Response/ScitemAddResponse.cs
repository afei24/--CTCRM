using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ScitemAddResponse.
    /// </summary>
    public class ScitemAddResponse : TopResponse
    {
        /// <summary>
        /// 后台商品信息
        /// </summary>
        [XmlElement("sc_item")]
        public Top.Api.Domain.ScItem ScItem { get; set; }

    }
}
