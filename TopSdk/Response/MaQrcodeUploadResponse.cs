using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// MaQrcodeUploadResponse.
    /// </summary>
    public class MaQrcodeUploadResponse : TopResponse
    {
        /// <summary>
        /// 图片链接
        /// </summary>
        [XmlElement("img_url")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 上传二维码图片是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 出错code,只有is_success=false才有值
        /// </summary>
        [XmlElement("reult_code")]
        public Top.Api.Domain.TopResultCode ReultCode { get; set; }

    }
}
