using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// UpdateItemShipTimeOption Data Structure.
    /// </summary>
    [Serializable]
    public class UpdateItemShipTimeOption : TopObject
    {
        /// <summary>
        /// 0代表清空所有发货时间数据；1代表：固定发货时间；2代表：相对发货时间
        /// </summary>
        [XmlElement("ship_time_type")]
        public long ShipTimeType { get; set; }

        /// <summary>
        /// 更新类型，默认更新sku，0表示更新sku，1表示更新商品维度，其他值均非法
        /// </summary>
        [XmlElement("update_type")]
        public long UpdateType { get; set; }
    }
}
