using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ItemMaterialInfo Data Structure.
    /// </summary>
    [Serializable]
    public class ItemMaterialInfo : TopObject
    {
        /// <summary>
        /// 素材id
        /// </summary>
        [XmlElement("material_id")]
        public string MaterialId { get; set; }

        /// <summary>
        /// itemId_skuId
        /// </summary>
        [XmlElement("source_id")]
        public string SourceId { get; set; }
    }
}
