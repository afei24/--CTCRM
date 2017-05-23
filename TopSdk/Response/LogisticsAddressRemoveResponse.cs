using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsAddressRemoveResponse.
    /// </summary>
    public class LogisticsAddressRemoveResponse : TopResponse
    {
        /// <summary>
        /// 只返回修改日期modify_date
        /// </summary>
        [XmlElement("address_result")]
        public Top.Api.Domain.AddressResult AddressResult { get; set; }

    }
}
