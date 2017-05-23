using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// UsersGetResponse.
    /// </summary>
    public class UsersGetResponse : TopResponse
    {
        /// <summary>
        /// 用户
        /// </summary>
        [XmlArray("users")]
        [XmlArrayItem("user")]
        public List<Top.Api.Domain.User> Users { get; set; }

    }
}
