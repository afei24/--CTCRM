using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoWaybillIiCancelResponse.
    /// </summary>
    public class CainiaoWaybillIiCancelResponse : TopResponse
    {
        /// <summary>
        /// 调用取消是否成功
        /// </summary>
        [XmlElement("cancel_result")]
        public bool CancelResult { get; set; }

    }
}
