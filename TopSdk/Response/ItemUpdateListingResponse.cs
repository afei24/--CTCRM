using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemUpdateListingResponse.
    /// </summary>
    public class ItemUpdateListingResponse : TopResponse
    {
        /// <summary>
        /// 上架后返回的商品信息：返回的结果就是:num_iid和modified
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.Item Item { get; set; }

    }
}
