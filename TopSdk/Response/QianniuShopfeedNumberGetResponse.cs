using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuShopfeedNumberGetResponse.
    /// </summary>
    public class QianniuShopfeedNumberGetResponse : TopResponse
    {
        /// <summary>
        /// 还能发布的店铺动态数量
        /// </summary>
        [XmlElement("number")]
        public Top.Api.Domain.CbInteractionFeedResultDo Number { get; set; }

    }
}
