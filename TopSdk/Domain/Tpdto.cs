using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Tpdto Data Structure.
    /// </summary>
    [Serializable]
    public class Tpdto : TopObject
    {
        /// <summary>
        /// 公司编码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 是否商家绑定的默认安装服务商
        /// </summary>
        [XmlElement("is_default")]
        public Nullable<bool> IsDefault { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
