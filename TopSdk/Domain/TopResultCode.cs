using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// TopResultCode Data Structure.
    /// </summary>
    [Serializable]
    public class TopResultCode : TopObject
    {
        /// <summary>
        /// code
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }
    }
}
