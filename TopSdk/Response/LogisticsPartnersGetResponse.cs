using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsPartnersGetResponse.
    /// </summary>
    public class LogisticsPartnersGetResponse : TopResponse
    {
        /// <summary>
        /// 查询揽送范围之内的物流公司信息
        /// </summary>
        [XmlArray("logistics_partners")]
        [XmlArrayItem("logistics_partner")]
        public List<Top.Api.Domain.LogisticsPartner> LogisticsPartners { get; set; }

    }
}
