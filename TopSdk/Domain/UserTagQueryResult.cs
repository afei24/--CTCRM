using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// UserTagQueryResult Data Structure.
    /// </summary>
    [Serializable]
    public class UserTagQueryResult : TopObject
    {
        /// <summary>
        /// 买家是否有这个标，true表示有，false表示没有
        /// </summary>
        [XmlElement("enterprise_buyer")]
        public bool EnterpriseBuyer { get; set; }
    }
}
