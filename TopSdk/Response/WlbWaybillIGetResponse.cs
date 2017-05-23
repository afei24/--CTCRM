using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWaybillIGetResponse.
    /// </summary>
    public class WlbWaybillIGetResponse : TopResponse
    {
        /// <summary>
        /// 面单申请接口返回信息
        /// </summary>
        [XmlArray("waybill_apply_new_cols")]
        [XmlArrayItem("waybill_apply_new_info")]
        public List<Top.Api.Domain.WaybillApplyNewInfo> WaybillApplyNewCols { get; set; }

    }
}
