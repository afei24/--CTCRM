using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuShopfeedFeedAddResponse.
    /// </summary>
    public class QianniuShopfeedFeedAddResponse : TopResponse
    {
        /// <summary>
        /// 新创建的店铺动态id
        /// </summary>
        [XmlElement("feed_id")]
        public long FeedId { get; set; }

    }
}
