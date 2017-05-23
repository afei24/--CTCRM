using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// KeludeQianniuBugsAddResponse.
    /// </summary>
    public class KeludeQianniuBugsAddResponse : TopResponse
    {
        /// <summary>
        /// 返回BUG的对象信息
        /// </summary>
        [XmlElement("bug")]
        public Top.Api.Domain.Bug Bug { get; set; }

    }
}
