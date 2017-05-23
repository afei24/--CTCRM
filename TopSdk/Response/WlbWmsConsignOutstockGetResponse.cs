using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsConsignOutstockGetResponse.
    /// </summary>
    public class WlbWmsConsignOutstockGetResponse : TopResponse
    {
        /// <summary>
        /// 商品发货信息列表
        /// </summary>
        [XmlArray("out_stock_info_list")]
        [XmlArrayItem("cainiao_consign_outstock_outstockinfolist")]
        public List<Top.Api.Domain.CainiaoConsignOutstockOutstockinfolist> OutStockInfoList { get; set; }

    }
}
