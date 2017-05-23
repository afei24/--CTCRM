using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbWmsInventoryQueryResponse.
    /// </summary>
    public class WlbWmsInventoryQueryResponse : TopResponse
    {
        /// <summary>
        /// 商品详情列表
        /// </summary>
        [XmlArray("item_list")]
        [XmlArrayItem("wms_inventory_query_itemlist")]
        public List<Top.Api.Domain.WmsInventoryQueryItemlist> ItemList { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

        /// <summary>
        /// 错误代码
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
