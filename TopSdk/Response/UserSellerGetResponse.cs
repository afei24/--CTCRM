using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// UserSellerGetResponse.
    /// </summary>
    public class UserSellerGetResponse : TopResponse
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        [XmlElement("user")]
        public Top.Api.Domain.User User { get; set; }

    }
}
