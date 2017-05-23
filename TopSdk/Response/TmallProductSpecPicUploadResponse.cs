using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallProductSpecPicUploadResponse.
    /// </summary>
    public class TmallProductSpecPicUploadResponse : TopResponse
    {
        /// <summary>
        /// 上传成功的产品规格认证图片url
        /// </summary>
        [XmlElement("spec_pic_url")]
        public string SpecPicUrl { get; set; }

    }
}
