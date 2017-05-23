using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// ItemMaterialProp Data Structure.
    /// </summary>
    [Serializable]
    public class ItemMaterialProp : TopObject
    {
        /// <summary>
        /// 材质值列表
        /// </summary>
        [XmlArray("materials")]
        [XmlArrayItem("item_materia_value_d_o")]
        public List<Top.Api.Domain.ItemMateriaValueDO> Materials { get; set; }
    }
}
