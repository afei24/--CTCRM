using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuTaskCancelResponse.
    /// </summary>
    public class QianniuTaskCancelResponse : TopResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("result")]
        public bool Result { get; set; }

    }
}
