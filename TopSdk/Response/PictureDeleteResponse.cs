using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PictureDeleteResponse.
    /// </summary>
    public class PictureDeleteResponse : TopResponse
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

    }
}
