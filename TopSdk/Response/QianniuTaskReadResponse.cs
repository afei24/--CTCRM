using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuTaskReadResponse.
    /// </summary>
    public class QianniuTaskReadResponse : TopResponse
    {
        /// <summary>
        /// 更新已读状态结果
        /// </summary>
        [XmlElement("result")]
        public bool Result { get; set; }

    }
}
