using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// UserTextcheckGetResponse.
    /// </summary>
    public class UserTextcheckGetResponse : TopResponse
    {
        /// <summary>
        /// 返回文本过滤结果
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
