using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuBuyerTagGetResponse.
    /// </summary>
    public class QianniuBuyerTagGetResponse : TopResponse
    {
        /// <summary>
        /// 用户tag信息
        /// </summary>
        [XmlElement("user_tag_info")]
        public Top.Api.Domain.UserTagQueryResult UserTagInfo { get; set; }

    }
}
