using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuTaskIncreaseResponse.
    /// </summary>
    public class QianniuTaskIncreaseResponse : TopResponse
    {
        /// <summary>
        /// 是否添加成功
        /// </summary>
        [XmlElement("result")]
        public bool Result { get; set; }

    }
}
