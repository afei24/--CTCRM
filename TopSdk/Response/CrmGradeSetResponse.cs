using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CrmGradeSetResponse.
    /// </summary>
    public class CrmGradeSetResponse : TopResponse
    {
        /// <summary>
        /// true：成功 false：失败
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
