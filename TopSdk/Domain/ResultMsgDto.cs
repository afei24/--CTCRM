using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// ResultMsgDto Data Structure.
    /// </summary>
    [Serializable]
    public class ResultMsgDto : TopObject
    {
        /// <summary>
        /// 数字知识详情
        /// </summary>
        [XmlElement("data")]
        public Top.Api.Domain.NumberSolutionDto Data { get; set; }

        /// <summary>
        /// 返回错误的消息
        /// </summary>
        [XmlElement("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 是否有权限访问
        /// </summary>
        [XmlElement("permission")]
        public bool Permission { get; set; }

        /// <summary>
        /// 成功升级至云端
        /// </summary>
        [XmlElement("ret")]
        public string Ret { get; set; }

        /// <summary>
        /// 返回数字知识列表
        /// </summary>
        [XmlArray("ret_list")]
        [XmlArrayItem("pamirs_ret")]
        public List<Top.Api.Domain.PamirsRet> RetList { get; set; }

        /// <summary>
        /// status
        /// </summary>
        [XmlElement("status")]
        public bool Status { get; set; }
    }
}
