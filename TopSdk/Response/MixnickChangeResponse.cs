using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// MixnickChangeResponse.
    /// </summary>
    public class MixnickChangeResponse : TopResponse
    {
        /// <summary>
        /// 根据dstAppkey算出的mixnick
        /// </summary>
        [XmlElement("mixnick")]
        public string Mixnick { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("ret_success")]
        public bool RetSuccess { get; set; }

    }
}
