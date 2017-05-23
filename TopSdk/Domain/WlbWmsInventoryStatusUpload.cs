using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// WlbWmsInventoryStatusUpload Data Structure.
    /// </summary>
    [Serializable]
    public class WlbWmsInventoryStatusUpload : TopObject
    {
        /// <summary>
        /// 订单商品信息列表
        /// </summary>
        [XmlElement("item_list")]
        public Top.Api.Domain.ItemListWlbWmsInventoryStatusUpload ItemList { get; set; }

        /// <summary>
        /// 订单编码
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 7
        /// </summary>
        [XmlElement("order_confirm_time")]
        public string OrderConfirmTime { get; set; }

        /// <summary>
        /// 711
        /// </summary>
        [XmlElement("order_type")]
        public Nullable<long> OrderType { get; set; }

        /// <summary>
        /// 000000000123
        /// </summary>
        [XmlElement("out_biz_code")]
        public string OutBizCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// STORE_000001
        /// </summary>
        [XmlElement("store_code")]
        public string StoreCode { get; set; }

        /// <summary>
        /// LBX00001
        /// </summary>
        [XmlElement("store_order_code")]
        public string StoreOrderCode { get; set; }
    }
}
