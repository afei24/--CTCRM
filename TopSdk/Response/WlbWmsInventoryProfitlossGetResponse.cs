using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsInventoryProfitlossGetResponse.
    /// </summary>
    public class WlbWmsInventoryProfitlossGetResponse : TopResponse
    {
        /// <summary>
        /// 损益信息
        /// </summary>
        [XmlElement("profit_loss_info")]
        public Top.Api.Domain.CainiaoInventoryProfitlossProfitlossinfo ProfitLossInfo { get; set; }

    }
}
