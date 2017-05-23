using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoGradesGetResponse.
    /// </summary>
    public class FenxiaoGradesGetResponse : TopResponse
    {
        /// <summary>
        /// 分销商等级信息
        /// </summary>
        [XmlArray("fenxiao_grades")]
        [XmlArrayItem("fenxiao_grade")]
        public List<Top.Api.Domain.FenxiaoGrade> FenxiaoGrades { get; set; }

    }
}
