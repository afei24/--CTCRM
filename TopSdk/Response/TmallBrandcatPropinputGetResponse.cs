using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallBrandcatPropinputGetResponse.
    /// </summary>
    public class TmallBrandcatPropinputGetResponse : TopResponse
    {
        /// <summary>
        /// 属性输入特征
        /// </summary>
        [XmlElement("property_input")]
        public Top.Api.Domain.PropertyInputDO PropertyInput { get; set; }

    }
}
