using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsAddressReachableResponse.
    /// </summary>
    public class LogisticsAddressReachableResponse : TopResponse
    {
        /// <summary>
        /// 地址可达返回结果，每个TP对应一个
        /// </summary>
        [XmlArray("reachable_result_list")]
        [XmlArrayItem("address_reachable_result")]
        public List<Top.Api.Domain.AddressReachableResult> ReachableResultList { get; set; }

    }
}
