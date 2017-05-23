using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsStockInBillGetResponse.
    /// </summary>
    public class WlbWmsStockInBillGetResponse : TopResponse
    {
        /// <summary>
        /// 入库单信息
        /// </summary>
        [XmlElement("stock_in_info")]
        public Top.Api.Domain.CainiaoStockInBillStockininfo StockInInfo { get; set; }

    }
}
