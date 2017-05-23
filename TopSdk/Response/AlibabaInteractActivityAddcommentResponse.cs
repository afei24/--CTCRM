using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractActivityAddcommentResponse.
    /// </summary>
    public class AlibabaInteractActivityAddcommentResponse : TopResponse
    {
        /// <summary>
        /// 评论的楼层数
        /// </summary>
        [XmlElement("floor")]
        public long Floor { get; set; }

        /// <summary>
        /// 返回成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
