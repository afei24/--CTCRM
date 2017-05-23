using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// PartnerNew Data Structure.
    /// </summary>
    [Serializable]
    public class PartnerNew : TopObject
    {
        /// <summary>
        /// 是否虚拟物流商
        /// </summary>
        [XmlElement("is_virtual_tp")]
        public bool IsVirtualTp { get; set; }

        /// <summary>
        /// 服务类型
        /// </summary>
        [XmlElement("service_type")]
        public long ServiceType { get; set; }

        /// <summary>
        /// 物流商编码
        /// </summary>
        [XmlElement("tp_code")]
        public string TpCode { get; set; }

        /// <summary>
        /// 物流商名称
        /// </summary>
        [XmlElement("tp_name")]
        public string TpName { get; set; }
    }
}
