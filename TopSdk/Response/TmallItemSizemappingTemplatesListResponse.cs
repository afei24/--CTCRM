using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallItemSizemappingTemplatesListResponse.
    /// </summary>
    public class TmallItemSizemappingTemplatesListResponse : TopResponse
    {
        /// <summary>
        /// 尺码表模板列表
        /// </summary>
        [XmlArray("size_mapping_templates")]
        [XmlArrayItem("size_mapping_template")]
        public List<Top.Api.Domain.SizeMappingTemplate> SizeMappingTemplates { get; set; }

    }
}
