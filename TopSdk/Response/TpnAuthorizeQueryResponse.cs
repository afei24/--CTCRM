using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TpnAuthorizeQueryResponse.
    /// </summary>
    public class TpnAuthorizeQueryResponse : TopResponse
    {
        /// <summary>
        /// 账号的订阅状态
        /// </summary>
        [XmlArray("subinfos")]
        [XmlArrayItem("string")]
        public List<string> Subinfos { get; set; }

    }
}
