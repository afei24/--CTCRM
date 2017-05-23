using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoDistributorsGetResponse.
    /// </summary>
    public class FenxiaoDistributorsGetResponse : TopResponse
    {
        /// <summary>
        /// 分销商详细信息
        /// </summary>
        [XmlArray("distributors")]
        [XmlArrayItem("distributor")]
        public List<Top.Api.Domain.Distributor> Distributors { get; set; }

    }
}
