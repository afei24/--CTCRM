using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuSolutionCheckResponse.
    /// </summary>
    public class QianniuSolutionCheckResponse : TopResponse
    {
        /// <summary>
        /// errorMsg
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 是否合法
        /// </summary>
        [XmlElement("result")]
        public bool Result { get; set; }

    }
}
