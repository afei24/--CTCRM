using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Destitemlistwlbwmsskucombinationcreateupdate Data Structure.
    /// </summary>
    [Serializable]
    public class Destitemlistwlbwmsskucombinationcreateupdate : TopObject
    {
        /// <summary>
        /// 组合子商品
        /// </summary>
        [XmlElement("dest_item")]
        public Top.Api.Domain.Destitemwlbwmsskucombinationcreateupdate DestItem { get; set; }
    }
}
