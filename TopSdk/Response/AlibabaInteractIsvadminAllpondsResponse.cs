using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractIsvadminAllpondsResponse.
    /// </summary>
    public class AlibabaInteractIsvadminAllpondsResponse : TopResponse
    {
        /// <summary>
        /// 奖池列表
        /// </summary>
        [XmlArray("allponds")]
        [XmlArrayItem("prize_pond_d_t_o")]
        public List<Top.Api.Domain.PrizePondDTO> Allponds { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("interact_error_code")]
        public string InteractErrorCode { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [XmlElement("interact_error_msg")]
        public string InteractErrorMsg { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("succ")]
        public bool Succ { get; set; }

    }
}
