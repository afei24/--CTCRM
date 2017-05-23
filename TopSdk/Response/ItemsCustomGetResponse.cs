using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemsCustomGetResponse.
    /// </summary>
    public class ItemsCustomGetResponse : TopResponse
    {
        /// <summary>
        /// 商品列表，具体返回字段以fields决定
        /// </summary>
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<Top.Api.Domain.Item> Items { get; set; }

    }
}
