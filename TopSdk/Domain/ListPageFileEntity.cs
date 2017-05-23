using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// ListPageFileEntity Data Structure.
    /// </summary>
    [Serializable]
    public class ListPageFileEntity : TopObject
    {
        /// <summary>
        /// objects
        /// </summary>
        [XmlArray("objects")]
        [XmlArrayItem("file_entity")]
        public List<Top.Api.Domain.FileEntity> Objects { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("offset")]
        public long Offset { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("page_count")]
        public long PageCount { get; set; }
    }
}
