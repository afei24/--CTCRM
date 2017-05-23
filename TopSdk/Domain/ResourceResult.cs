using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// ResourceResult Data Structure.
    /// </summary>
    [Serializable]
    public class ResourceResult : TopObject
    {
        /// <summary>
        /// 服务报价。首重（1磅) CNY￥3元 续重（1磅) CNY￥6元
        /// </summary>
        [XmlElement("delivery_price")]
        public Top.Api.Domain.DeliveryPrice DeliveryPrice { get; set; }

        /// <summary>
        /// 时效，单位（小时）
        /// </summary>
        [XmlElement("delivery_time")]
        public long DeliveryTime { get; set; }

        /// <summary>
        /// 资源代码
        /// </summary>
        [XmlElement("res_code")]
        public string ResCode { get; set; }

        /// <summary>
        /// 资源ID
        /// </summary>
        [XmlElement("res_id")]
        public long ResId { get; set; }

        /// <summary>
        /// 魔方天下美国线
        /// </summary>
        [XmlElement("resource_name")]
        public string ResourceName { get; set; }
    }
}
