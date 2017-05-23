using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoOrdersGetResponse.
    /// </summary>
    public class FenxiaoOrdersGetResponse : TopResponse
    {
        /// <summary>
        /// 采购单及子采购单信息。返回 PurchaseOrder 包含的字段信息。
        /// </summary>
        [XmlArray("purchase_orders")]
        [XmlArrayItem("purchase_order")]
        public List<Top.Api.Domain.PurchaseOrder> PurchaseOrders { get; set; }

        /// <summary>
        /// 搜索到的采购单记录总数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }

    }
}
