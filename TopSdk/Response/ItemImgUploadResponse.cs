using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemImgUploadResponse.
    /// </summary>
    public class ItemImgUploadResponse : TopResponse
    {
        /// <summary>
        /// 商品图片结构
        /// </summary>
        [XmlElement("item_img")]
        public Top.Api.Domain.ItemImg ItemImg { get; set; }

    }
}
