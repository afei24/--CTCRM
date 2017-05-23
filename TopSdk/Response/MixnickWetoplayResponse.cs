using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// MixnickWetoplayResponse.
    /// </summary>
    public class MixnickWetoplayResponse : TopResponse
    {
        /// <summary>
        /// 微淘转互动混淆nick
        /// </summary>
        [XmlElement("play_mixnick_data")]
        public Top.Api.Domain.MixNickResult PlayMixnickData { get; set; }

    }
}
