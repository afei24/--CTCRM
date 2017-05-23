using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Lgcps Data Structure.
    /// </summary>
    [Serializable]
    public class Lgcps : TopObject
    {
        /// <summary>
        /// 公司编码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
