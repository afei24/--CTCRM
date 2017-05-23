using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// MixnickGetResponse.
    /// </summary>
    public class MixnickGetResponse : TopResponse
    {
        /// <summary>
        /// 混淆后的用户名
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }

    }
}
