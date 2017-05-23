using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoWaybillIiUpdateResponse.
    /// </summary>
    public class CainiaoWaybillIiUpdateResponse : TopResponse
    {
        /// <summary>
        /// 模板内容
        /// </summary>
        [XmlElement("print_data")]
        public string PrintData { get; set; }

        /// <summary>
        /// 面单号
        /// </summary>
        [XmlElement("waybill_code")]
        public string WaybillCode { get; set; }

    }
}
