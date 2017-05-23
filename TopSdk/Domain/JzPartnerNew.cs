using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// JzPartnerNew Data Structure.
    /// </summary>
    [Serializable]
    public class JzPartnerNew : TopObject
    {
        /// <summary>
        /// 是否是虚拟服务商（家装-商家自有物流）
        /// </summary>
        [XmlElement("is_virtual_tp")]
        public Nullable<bool> IsVirtualTp { get; set; }

        /// <summary>
        /// 服务类型
        /// </summary>
        [XmlElement("service_type")]
        public Nullable<long> ServiceType { get; set; }

        /// <summary>
        /// 服务商编码
        /// </summary>
        [XmlElement("tp_code")]
        public string TpCode { get; set; }

        /// <summary>
        /// 服务商名称
        /// </summary>
        [XmlElement("tp_name")]
        public string TpName { get; set; }
    }
}
