using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbItemMapGetResponse.
    /// </summary>
    public class WlbItemMapGetResponse : TopResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 外部商品实体
        /// </summary>
        [XmlArray("out_entity_item_list")]
        [XmlArrayItem("out_entity_item")]
        public List<Top.Api.Domain.OutEntityItem> OutEntityItemList { get; set; }

    }
}
