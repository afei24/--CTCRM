using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoProductMapAddResponse.
    /// </summary>
    public class FenxiaoProductMapAddResponse : TopResponse
    {
        /// <summary>
        /// 操作结果
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
