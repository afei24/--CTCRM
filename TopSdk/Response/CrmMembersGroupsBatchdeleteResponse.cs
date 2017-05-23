using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CrmMembersGroupsBatchdeleteResponse.
    /// </summary>
    public class CrmMembersGroupsBatchdeleteResponse : TopResponse
    {
        /// <summary>
        /// 删除是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
