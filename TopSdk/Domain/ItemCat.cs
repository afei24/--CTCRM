using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// ItemCat Data Structure.
    /// </summary>
    [Serializable]
    public class ItemCat : TopObject
    {
        /// <summary>
        /// 商品所属类目ID
        /// </summary>
        [XmlElement("cid")]
        public long Cid { get; set; }

        /// <summary>
        /// Feature对象列表  目前已有的属性：  若Attr_key为 udsaleprop，attr_value为1 则允许卖家在改类目新增自定义销售属性,不然为不允许
        /// </summary>
        [XmlArray("features")]
        [XmlArrayItem("feature")]
        public List<Top.Api.Domain.Feature> Features { get; set; }

        /// <summary>
        /// 该类目是否为父类目(即：该类目是否还有子类目)
        /// </summary>
        [XmlElement("is_parent")]
        public bool IsParent { get; set; }

        /// <summary>
        /// 类目名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 父类目ID=0时，代表的是一级的类目
        /// </summary>
        [XmlElement("parent_cid")]
        public long ParentCid { get; set; }

        /// <summary>
        /// 排列序号，表示同级类目的展现次序，如数值相等则按名称次序排列。取值范围:大于零的整数
        /// </summary>
        [XmlElement("sort_order")]
        public long SortOrder { get; set; }

        /// <summary>
        /// 状态。可选值:normal(正常),deleted(删除)
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 是否度量衡类目
        /// </summary>
        [XmlElement("taosir_cat")]
        public bool TaosirCat { get; set; }
    }
}
