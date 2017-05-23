using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmcMsgSendrecordResponse.
    /// </summary>
    public class TmcMsgSendrecordResponse : TopResponse
    {
        /// <summary>
        /// 淘宝发送时间
        /// </summary>
        [XmlElement("tb_send_list")]
        public string TbSendList { get; set; }

        /// <summary>
        /// 淘宝发送测试
        /// </summary>
        [XmlElement("tb_send_times")]
        public long TbSendTimes { get; set; }

        /// <summary>
        /// TMC发送时间
        /// </summary>
        [XmlElement("tmc_send_list")]
        public string TmcSendList { get; set; }

        /// <summary>
        /// tmc发送次数
        /// </summary>
        [XmlElement("tmc_send_times")]
        public long TmcSendTimes { get; set; }

    }
}
