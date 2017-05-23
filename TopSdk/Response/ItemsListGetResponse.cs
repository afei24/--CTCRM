using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemsListGetResponse.
    /// </summary>
    public class ItemsListGetResponse : TopResponse
    {
        /// <summary>
        /// 获取的商品 具体字段根据权限和设定的fields决定
        /// </summary>
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<Top.Api.Domain.Item> Items { get; set; }

    }
}
