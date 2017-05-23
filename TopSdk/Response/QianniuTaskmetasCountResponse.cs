using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuTaskmetasCountResponse.
    /// </summary>
    public class QianniuTaskmetasCountResponse : TopResponse
    {
        /// <summary>
        /// 符合查询条件的总条数
        /// </summary>
        [XmlElement("result")]
        public long Result { get; set; }

    }
}
