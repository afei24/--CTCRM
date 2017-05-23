using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// JzTopArgs Data Structure.
    /// </summary>
    [Serializable]
    public class JzTopArgs : TopObject
    {
        /// <summary>
        /// 运单号
        /// </summary>
        [XmlElement("mail_no")]
        public string MailNo { get; set; }

        /// <summary>
        /// 包裹数量
        /// </summary>
        [XmlElement("package_number")]
        public string PackageNumber { get; set; }

        /// <summary>
        /// 包裹备注
        /// </summary>
        [XmlElement("package_remark")]
        public string PackageRemark { get; set; }

        /// <summary>
        /// 包裹体积
        /// </summary>
        [XmlElement("package_volume")]
        public string PackageVolume { get; set; }

        /// <summary>
        /// 包裹重量
        /// </summary>
        [XmlElement("package_weight")]
        public string PackageWeight { get; set; }

        /// <summary>
        /// 自有物流公司名称
        /// </summary>
        [XmlElement("zy_company")]
        public string ZyCompany { get; set; }

        /// <summary>
        /// 自有物流发货时间
        /// </summary>
        [XmlElement("zy_consign_time")]
        public string ZyConsignTime { get; set; }

        /// <summary>
        /// 自有物流公司电话
        /// </summary>
        [XmlElement("zy_phone_number")]
        public string ZyPhoneNumber { get; set; }
    }
}
