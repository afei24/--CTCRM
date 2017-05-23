using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// AccountReceptionAbilityDO Data Structure.
    /// </summary>
    [Serializable]
    public class AccountReceptionAbilityDO : TopObject
    {
        /// <summary>
        /// 账号id
        /// </summary>
        [XmlElement("account_id")]
        public long AccountId { get; set; }

        /// <summary>
        /// 待接待人数
        /// </summary>
        [XmlElement("awaited_number")]
        public long AwaitedNumber { get; set; }
    }
}
