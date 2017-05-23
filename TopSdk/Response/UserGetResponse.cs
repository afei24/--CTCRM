using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// UserGetResponse.
    /// </summary>
    public class UserGetResponse : TopResponse
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        [XmlElement("user")]
        public Top.Api.Domain.User User { get; set; }

    }
}
