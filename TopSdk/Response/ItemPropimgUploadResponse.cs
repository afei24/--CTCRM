using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemPropimgUploadResponse.
    /// </summary>
    public class ItemPropimgUploadResponse : TopResponse
    {
        /// <summary>
        /// PropImg属性图片结构
        /// </summary>
        [XmlElement("prop_img")]
        public Top.Api.Domain.PropImg PropImg { get; set; }

    }
}
