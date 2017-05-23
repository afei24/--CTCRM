using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoBimTradeorderConsignResponse.
    /// </summary>
    public class CainiaoBimTradeorderConsignResponse : TopResponse
    {
        /// <summary>
        /// 菜鸟物流订单号,格式为LP开头
        /// </summary>
        [XmlElement("lg_order_code")]
        public string LgOrderCode { get; set; }

        /// <summary>
        /// 菜鸟仓库作业单据号
        /// </summary>
        [XmlElement("store_order_code")]
        public string StoreOrderCode { get; set; }

    }
}
