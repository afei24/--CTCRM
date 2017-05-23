using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallProductTemplateGetResponse.
    /// </summary>
    public class TmallProductTemplateGetResponse : TopResponse
    {
        /// <summary>
        /// 见SpuTemplateDO说明
        /// </summary>
        [XmlElement("template")]
        public Top.Api.Domain.SpuTemplateDO Template { get; set; }

    }
}
