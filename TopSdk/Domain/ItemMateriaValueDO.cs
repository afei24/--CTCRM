using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ItemMateriaValueDO Data Structure.
    /// </summary>
    [Serializable]
    public class ItemMateriaValueDO : TopObject
    {
        /// <summary>
        /// 材质值名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 当前材质值，是否需要填写含量值。比如：棉 是需要填写含量值，而牛皮 是不需要填写含量值的
        /// </summary>
        [XmlElement("need_content_number")]
        public bool NeedContentNumber { get; set; }
    }
}
