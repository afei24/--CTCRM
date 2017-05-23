using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuShopfeedReleaseGetResponse.
    /// </summary>
    public class QianniuShopfeedReleaseGetResponse : TopResponse
    {
        /// <summary>
        /// 已发布的店铺动态列表
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.CbInteractionFeedResultDo Result { get; set; }

    }
}
