using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PicturePicturesCountResponse.
    /// </summary>
    public class PicturePicturesCountResponse : TopResponse
    {
        /// <summary>
        /// 查询的文件总数
        /// </summary>
        [XmlElement("totals")]
        public long Totals { get; set; }

    }
}
