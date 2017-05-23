using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemsSellerListGetResponse.
    /// </summary>
    public class ItemsSellerListGetResponse : TopResponse
    {
        /// <summary>
        /// 商品详细信息列表
        /// </summary>
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<Top.Api.Domain.Item> Items { get; set; }

    }
}
