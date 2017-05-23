using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemJointPropimgResponse.
    /// </summary>
    public class ItemJointPropimgResponse : TopResponse
    {
        /// <summary>
        /// 属性图片对象信息
        /// </summary>
        [XmlElement("prop_img")]
        public Top.Api.Domain.PropImg PropImg { get; set; }

    }
}
