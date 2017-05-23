using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FuwuSpBillreordAddResponse.
    /// </summary>
    public class FuwuSpBillreordAddResponse : TopResponse
    {
        /// <summary>
        /// 返回调用结果
        /// </summary>
        [XmlElement("add_result")]
        public bool AddResult { get; set; }

    }
}
