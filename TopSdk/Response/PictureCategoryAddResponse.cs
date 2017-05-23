using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PictureCategoryAddResponse.
    /// </summary>
    public class PictureCategoryAddResponse : TopResponse
    {
        /// <summary>
        /// 图片分类信息
        /// </summary>
        [XmlElement("picture_category")]
        public Top.Api.Domain.PictureCategory PictureCategory { get; set; }

    }
}
