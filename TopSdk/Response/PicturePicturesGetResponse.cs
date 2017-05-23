using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PicturePicturesGetResponse.
    /// </summary>
    public class PicturePicturesGetResponse : TopResponse
    {
        /// <summary>
        /// 图片空间图片数据对象
        /// </summary>
        [XmlArray("pictures")]
        [XmlArrayItem("picture")]
        public List<Top.Api.Domain.Picture> Pictures { get; set; }

    }
}
