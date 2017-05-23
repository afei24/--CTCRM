using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CrmQnLabelsSellerGetResponse.
    /// </summary>
    public class CrmQnLabelsSellerGetResponse : TopResponse
    {
        /// <summary>
        /// 查询到的当前卖家的当前页的会员
        /// </summary>
        [XmlArray("groups")]
        [XmlArrayItem("group")]
        public List<Top.Api.Domain.Group> Groups { get; set; }

    }
}
