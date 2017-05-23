using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// FileEntity Data Structure.
    /// </summary>
    [Serializable]
    public class FileEntity : TopObject
    {
        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("content_type")]
        public long ContentType { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("creater_id")]
        public long CreaterId { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("describe")]
        public string Describe { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("download_url")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("extension")]
        public string Extension { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("file_id")]
        public long FileId { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("file_id_string")]
        public string FileIdString { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("file_type")]
        public long FileType { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("inode_id")]
        public string InodeId { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("is_share_file")]
        public bool IsShareFile { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("length")]
        public long Length { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("link_mark")]
        public long LinkMark { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("md5")]
        public string Md5 { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("modified_time")]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("mount_space_id")]
        public long MountSpaceId { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("parent_id")]
        public long ParentId { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("parent_id_string")]
        public string ParentIdString { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("path")]
        public string Path { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("space_id")]
        public long SpaceId { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("space_type")]
        public long SpaceType { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("thumbnail_prefix")]
        public string ThumbnailPrefix { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [XmlElement("version")]
        public long Version { get; set; }
    }
}
