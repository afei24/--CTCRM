using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuShopfeedDraftGetResponse.
    /// </summary>
    public class QianniuShopfeedDraftGetResponse : TopResponse
    {
        /// <summary>
        /// 草稿动态
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.CbInteractionFeedResultDo Result { get; set; }

    }
}
