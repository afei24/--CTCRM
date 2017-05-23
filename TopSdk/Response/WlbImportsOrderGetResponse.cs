using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbImportsOrderGetResponse.
    /// </summary>
    public class WlbImportsOrderGetResponse : TopResponse
    {
        /// <summary>
        /// 物流订单信息
        /// </summary>
        [XmlArray("orders")]
        [XmlArrayItem("loc_order")]
        public List<Top.Api.Domain.LocOrder> Orders { get; set; }

        /// <summary>
        /// 搜索到的总数量
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }

    }
}
