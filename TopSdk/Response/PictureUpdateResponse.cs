using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PictureUpdateResponse.
    /// </summary>
    public class PictureUpdateResponse : TopResponse
    {
        /// <summary>
        /// 更新是否成功
        /// </summary>
        [XmlElement("done")]
        public bool Done { get; set; }

    }
}
