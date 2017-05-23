using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWaybillIPrintResponse.
    /// </summary>
    public class WlbWaybillIPrintResponse : TopResponse
    {
        /// <summary>
        /// 面单打印信息
        /// </summary>
        [XmlArray("waybill_apply_print_check_infos")]
        [XmlArrayItem("waybill_apply_print_check_info")]
        public List<Top.Api.Domain.WaybillApplyPrintCheckInfo> WaybillApplyPrintCheckInfos { get; set; }

    }
}
