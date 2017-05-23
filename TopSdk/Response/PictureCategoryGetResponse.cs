using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PictureCategoryGetResponse.
    /// </summary>
    public class PictureCategoryGetResponse : TopResponse
    {
        /// <summary>
        /// 图片分类
        /// </summary>
        [XmlArray("picture_categories")]
        [XmlArrayItem("picture_category")]
        public List<Top.Api.Domain.PictureCategory> PictureCategories { get; set; }

    }
}
