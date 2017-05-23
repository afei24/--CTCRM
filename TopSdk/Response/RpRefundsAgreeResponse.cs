using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// RpRefundsAgreeResponse.
    /// </summary>
    public class RpRefundsAgreeResponse : TopResponse
    {
        /// <summary>
        /// 信息
        /// </summary>
        [XmlElement("message")]
        public string Message { get; set; }

        /// <summary>
        /// 批量退款操作情况，可选值：OP_SUCC（全部成功），SOME_OP_SUCC（部分成功），OP_FAILURE_UE（全部失败）
        /// </summary>
        [XmlElement("msg_code")]
        public string MsgCode { get; set; }

        /// <summary>
        /// 退款操作结果列表
        /// </summary>
        [XmlArray("results")]
        [XmlArrayItem("refund_mapping_result")]
        public List<Top.Api.Domain.RefundMappingResult> Results { get; set; }

        /// <summary>
        /// 操作成功
        /// </summary>
        [XmlElement("succ")]
        public bool Succ { get; set; }

    }
}
