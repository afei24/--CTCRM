using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// UserPortraitGetResponse.
    /// </summary>
    public class UserPortraitGetResponse : TopResponse
    {
        /// <summary>
        /// 用户画像信息
        /// </summary>
        [XmlElement("user")]
        public Top.Api.Domain.User User { get; set; }

    }
}
