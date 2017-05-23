using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WmsOrderWarehouseRouteGetResponse.
    /// </summary>
    public class WmsOrderWarehouseRouteGetResponse : TopResponse
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        [XmlArray("items")]
        [XmlArrayItem("order_warehouse_route_get_items")]
        public List<Top.Api.Domain.OrderWarehouseRouteGetItems> Items { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("wl_error_code")]
        public string WlErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("wl_error_msg")]
        public string WlErrorMsg { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("wl_success")]
        public bool WlSuccess { get; set; }

    }
}
