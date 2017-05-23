using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuShopfeedItemTitleGetResponse.
    /// </summary>
    public class QianniuShopfeedItemTitleGetResponse : TopResponse
    {
        /// <summary>
        /// 如果是商品detail 链接，则返回对应商品的title
        /// </summary>
        [XmlElement("title")]
        public Top.Api.Domain.CbInteractionFeedResultDo Title { get; set; }

    }
}
