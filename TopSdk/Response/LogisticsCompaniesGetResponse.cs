using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// LogisticsCompaniesGetResponse.
    /// </summary>
    public class LogisticsCompaniesGetResponse : TopResponse
    {
        /// <summary>
        /// 物流公司信息。返回的LogisticCompany包含的具体信息为入参fields请求的字段信息。
        /// </summary>
        [XmlArray("logistics_companies")]
        [XmlArrayItem("logistics_company")]
        public List<Top.Api.Domain.LogisticsCompany> LogisticsCompanies { get; set; }

    }
}
