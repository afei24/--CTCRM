using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemcatsGetResponse.
    /// </summary>
    public class ItemcatsGetResponse : TopResponse
    {
        /// <summary>
        /// 增量类目信息,根据fields传入的参数返回相应的结果；增量类目信息,根据fields传入的参数返回相应的结果。 features字段： 1、如果存在attr_key=freeze表示该类目被冻结了，attr_value=0,5，value可能存在2个值（也可能只有1个），用逗号分割，0表示禁编辑，5表示禁止发布
        /// </summary>
        [XmlArray("item_cats")]
        [XmlArrayItem("item_cat")]
        public List<Top.Api.Domain.ItemCat> ItemCats { get; set; }

        /// <summary>
        /// 最近修改时间(如果取增量，会返回该字段)。
        /// </summary>
        [XmlElement("last_modified")]
        public string LastModified { get; set; }

    }
}
