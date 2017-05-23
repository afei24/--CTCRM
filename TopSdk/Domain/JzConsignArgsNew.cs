using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// JzConsignArgsNew Data Structure.
    /// </summary>
    [Serializable]
    public class JzConsignArgsNew : TopObject
    {
        /// <summary>
        /// 快递运单号，serviceType=20 和serviceType=21时必填
        /// </summary>
        [XmlElement("mail_no")]
        public string MailNo { get; set; }

        /// <summary>
        /// 包裹数目
        /// </summary>
        [XmlElement("package_number")]
        public string PackageNumber { get; set; }

        /// <summary>
        /// 包裹备注信息
        /// </summary>
        [XmlElement("package_remark")]
        public string PackageRemark { get; set; }

        /// <summary>
        /// 包裹体积m3
        /// </summary>
        [XmlElement("package_volume")]
        public string PackageVolume { get; set; }

        /// <summary>
        /// 包裹重量kg
        /// </summary>
        [XmlElement("package_weight")]
        public string PackageWeight { get; set; }

        /// <summary>
        /// 物流公司名称，tmsPartner.virualType=true时必填
        /// </summary>
        [XmlElement("zy_company")]
        public string ZyCompany { get; set; }

        /// <summary>
        /// 发货时间，tmsPartner.virualType=true时必填
        /// </summary>
        [XmlElement("zy_consign_time")]
        public string ZyConsignTime { get; set; }

        /// <summary>
        /// 运单号，tmsPartner.virualType=true时必填
        /// </summary>
        [XmlElement("zy_mail_no")]
        public string ZyMailNo { get; set; }

        /// <summary>
        /// 物流公司电话，tmsPartner.virualType=true时必填
        /// </summary>
        [XmlElement("zy_phone_number")]
        public string ZyPhoneNumber { get; set; }
    }
}
