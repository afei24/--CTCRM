using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemPropimgDeleteResponse.
    /// </summary>
    public class ItemPropimgDeleteResponse : TopResponse
    {
        /// <summary>
        /// 属性图片结构
        /// </summary>
        [XmlElement("prop_img")]
        public Top.Api.Domain.PropImg PropImg { get; set; }

    }
}
