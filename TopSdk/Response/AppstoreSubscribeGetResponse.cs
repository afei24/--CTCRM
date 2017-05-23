using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AppstoreSubscribeGetResponse.
    /// </summary>
    public class AppstoreSubscribeGetResponse : TopResponse
    {
        /// <summary>
        /// 用户订购信息
        /// </summary>
        [XmlElement("user_subscribe")]
        public Top.Api.Domain.UserSubscribe UserSubscribe { get; set; }

    }
}
