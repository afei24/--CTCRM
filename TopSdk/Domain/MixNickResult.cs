using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// MixNickResult Data Structure.
    /// </summary>
    [Serializable]
    public class MixNickResult : TopObject
    {
        /// <summary>
        /// 互动混淆nick
        /// </summary>
        [XmlElement("play_mixnick")]
        public string PlayMixnick { get; set; }
    }
}
