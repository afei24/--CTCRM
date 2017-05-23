using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWaybillIFullupdateResponse.
    /// </summary>
    public class WlbWaybillIFullupdateResponse : TopResponse
    {
        /// <summary>
        /// 更新接口出参
        /// </summary>
        [XmlElement("waybill_apply_update_info")]
        public Top.Api.Domain.WaybillApplyUpdateInfo WaybillApplyUpdateInfo { get; set; }

    }
}
