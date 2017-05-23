using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// Destitemwlbwmsskucombinationcreateupdate Data Structure.
    /// </summary>
    [Serializable]
    public class Destitemwlbwmsskucombinationcreateupdate : TopObject
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }
    }
}
