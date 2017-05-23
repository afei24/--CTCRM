using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoProductMapDeleteResponse.
    /// </summary>
    public class FenxiaoProductMapDeleteResponse : TopResponse
    {
        /// <summary>
        /// 操作结果
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
