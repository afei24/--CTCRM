using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemJointImgResponse.
    /// </summary>
    public class ItemJointImgResponse : TopResponse
    {
        /// <summary>
        /// 商品图片信息
        /// </summary>
        [XmlElement("item_img")]
        public Top.Api.Domain.ItemImg ItemImg { get; set; }

    }
}
