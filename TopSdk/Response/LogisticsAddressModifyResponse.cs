using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsAddressModifyResponse.
    /// </summary>
    public class LogisticsAddressModifyResponse : TopResponse
    {
        /// <summary>
        /// 只返回修改时间modify_date
        /// </summary>
        [XmlElement("address_result")]
        public Top.Api.Domain.AddressResult AddressResult { get; set; }

    }
}
