using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuTaskFinishResponse.
    /// </summary>
    public class QianniuTaskFinishResponse : TopResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("result")]
        public bool Result { get; set; }

    }
}
