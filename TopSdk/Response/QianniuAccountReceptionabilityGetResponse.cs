using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// QianniuAccountReceptionabilityGetResponse.
    /// </summary>
    public class QianniuAccountReceptionabilityGetResponse : TopResponse
    {
        /// <summary>
        /// 账号待接待能力
        /// </summary>
        [XmlArray("account_reception_ability_list")]
        [XmlArrayItem("account_reception_ability_d_o")]
        public List<Top.Api.Domain.AccountReceptionAbilityDO> AccountReceptionAbilityList { get; set; }

    }
}
