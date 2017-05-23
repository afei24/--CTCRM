using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsAddressSearchResponse.
    /// </summary>
    public class LogisticsAddressSearchResponse : TopResponse
    {
        /// <summary>
        /// 一组地址库数据，
        /// </summary>
        [XmlArray("addresses")]
        [XmlArrayItem("address_result")]
        public List<Top.Api.Domain.AddressResult> Addresses { get; set; }

    }
}
