using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// DeliveryTemplateAddResponse.
    /// </summary>
    public class DeliveryTemplateAddResponse : TopResponse
    {
        /// <summary>
        /// 模板对象
        /// </summary>
        [XmlElement("delivery_template")]
        public Top.Api.Domain.DeliveryTemplate DeliveryTemplate { get; set; }

    }
}
