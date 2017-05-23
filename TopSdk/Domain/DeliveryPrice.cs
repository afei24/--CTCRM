using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// DeliveryPrice Data Structure.
    /// </summary>
    [Serializable]
    public class DeliveryPrice : TopObject
    {
        /// <summary>
        /// 首重
        /// </summary>
        [XmlElement("basic_weight")]
        public long BasicWeight { get; set; }

        /// <summary>
        /// 首重价格
        /// </summary>
        [XmlElement("basic_weight_price")]
        public long BasicWeightPrice { get; set; }

        /// <summary>
        /// 续重
        /// </summary>
        [XmlElement("step_weight")]
        public long StepWeight { get; set; }

        /// <summary>
        /// 续重价格
        /// </summary>
        [XmlElement("step_weight_price")]
        public long StepWeightPrice { get; set; }
    }
}
