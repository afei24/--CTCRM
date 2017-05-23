using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractIsvadminGetinteractbysellernickResponse.
    /// </summary>
    public class AlibabaInteractIsvadminGetinteractbysellernickResponse : TopResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回业务数据
        /// </summary>
        [XmlArray("interactdtos")]
        [XmlArrayItem("interact_d_t_o")]
        public List<Top.Api.Domain.InteractDTO> Interactdtos { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("msginfo")]
        public string Msginfo { get; set; }

        /// <summary>
        /// 返回结果是否成功
        /// </summary>
        [XmlElement("succ")]
        public bool Succ { get; set; }

    }
}
