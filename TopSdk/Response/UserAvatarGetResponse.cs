using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// UserAvatarGetResponse.
    /// </summary>
    public class UserAvatarGetResponse : TopResponse
    {
        /// <summary>
        /// 用户头像地址
        /// </summary>
        [XmlElement("avatar")]
        public string Avatar { get; set; }

    }
}
