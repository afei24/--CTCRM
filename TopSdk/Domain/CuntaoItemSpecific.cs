using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CuntaoItemSpecific Data Structure.
    /// </summary>
    [Serializable]
    public class CuntaoItemSpecific : TopObject
    {
        /// <summary>
        /// 村淘商品级佣金率
        /// </summary>
        [XmlElement("kick_back_rate")]
        public string KickBackRate { get; set; }
    }
}
