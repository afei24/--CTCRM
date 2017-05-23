using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PictureUploadResponse.
    /// </summary>
    public class PictureUploadResponse : TopResponse
    {
        /// <summary>
        /// 当前上传的一张图片信息
        /// </summary>
        [XmlElement("picture")]
        public Top.Api.Domain.Picture Picture { get; set; }

    }
}
