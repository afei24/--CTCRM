using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsStockOutBillGetResponse.
    /// </summary>
    public class WlbWmsStockOutBillGetResponse : TopResponse
    {
        /// <summary>
        /// 出库信息
        /// </summary>
        [XmlElement("stock_out_info")]
        public Top.Api.Domain.CainiaoStockOutBillStockoutinfo StockOutInfo { get; set; }

    }
}
