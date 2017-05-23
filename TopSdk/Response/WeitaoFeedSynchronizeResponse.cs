using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WeitaoFeedSynchronizeResponse.
    /// </summary>
    public class WeitaoFeedSynchronizeResponse : TopResponse
    {
        /// <summary>
        /// 增加错误信息
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 同步到微淘成功与否
        /// </summary>
        [XmlElement("result")]
        public bool Result { get; set; }

    }
}
