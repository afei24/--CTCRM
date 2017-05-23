using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PamirsathenaSolutionUpgradeResponse.
    /// </summary>
    public class PamirsathenaSolutionUpgradeResponse : TopResponse
    {
        /// <summary>
        /// 用户升级至云端
        /// </summary>
        [XmlElement("ret_data")]
        public Top.Api.Domain.ResultMsgDto RetData { get; set; }

    }
}
