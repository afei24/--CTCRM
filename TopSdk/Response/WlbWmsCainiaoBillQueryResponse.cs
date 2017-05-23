using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsCainiaoBillQueryResponse.
    /// </summary>
    public class WlbWmsCainiaoBillQueryResponse : TopResponse
    {
        /// <summary>
        /// 订单列表信息
        /// </summary>
        [XmlArray("order_info_list")]
        [XmlArrayItem("cainiao_bill_query_orderinfolist")]
        public List<Top.Api.Domain.CainiaoBillQueryOrderinfolist> OrderInfoList { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

    }
}
