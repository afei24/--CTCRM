using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoWaybillprintClientupdateGetconfigResponse.
    /// </summary>
    public class CainiaoWaybillprintClientupdateGetconfigResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public UpdateConfigTopResultDomain Result { get; set; }

	/// <summary>
/// UpdateConfigActInfoDomain Data Structure.
/// </summary>
[Serializable]
public class UpdateConfigActInfoDomain : TopObject
{
	        /// <summary>
	        /// url
	        /// </summary>
	        [XmlElement("url")]
	        public string Url { get; set; }
	
	        /// <summary>
	        /// version
	        /// </summary>
	        [XmlElement("version")]
	        public string Version { get; set; }
}

	/// <summary>
/// UpdateConfigMsgInfoDomain Data Structure.
/// </summary>
[Serializable]
public class UpdateConfigMsgInfoDomain : TopObject
{
	        /// <summary>
	        /// msg
	        /// </summary>
	        [XmlElement("msg")]
	        public string Msg { get; set; }
	
	        /// <summary>
	        /// msgid
	        /// </summary>
	        [XmlElement("msgid")]
	        public long Msgid { get; set; }
}

	/// <summary>
/// UpdateConfigTopResultDomain Data Structure.
/// </summary>
[Serializable]
public class UpdateConfigTopResultDomain : TopObject
{
	        /// <summary>
	        /// actDescription
	        /// </summary>
	        [XmlElement("act_description")]
	        public string ActDescription { get; set; }
	
	        /// <summary>
	        /// actStatus
	        /// </summary>
	        [XmlElement("act_status")]
	        public long ActStatus { get; set; }
	
	        /// <summary>
	        /// description
	        /// </summary>
	        [XmlElement("description")]
	        public string Description { get; set; }
	
	        /// <summary>
	        /// enforceUpdate
	        /// </summary>
	        [XmlElement("enforce_update")]
	        public UpdateConfigActInfoDomain EnforceUpdate { get; set; }
	
	        /// <summary>
	        /// grayCtrl
	        /// </summary>
	        [XmlElement("gray_ctrl")]
	        public UpdateConfigActInfoDomain GrayCtrl { get; set; }
	
	        /// <summary>
	        /// msgDescription
	        /// </summary>
	        [XmlElement("msg_description")]
	        public string MsgDescription { get; set; }
	
	        /// <summary>
	        /// msgStatus
	        /// </summary>
	        [XmlElement("msg_status")]
	        public long MsgStatus { get; set; }
	
	        /// <summary>
	        /// notice
	        /// </summary>
	        [XmlElement("notice")]
	        public UpdateConfigMsgInfoDomain Notice { get; set; }
	
	        /// <summary>
	        /// noticeFlag
	        /// </summary>
	        [XmlElement("notice_flag")]
	        public bool NoticeFlag { get; set; }
	
	        /// <summary>
	        /// rollback
	        /// </summary>
	        [XmlElement("rollback")]
	        public UpdateConfigActInfoDomain Rollback { get; set; }
	
	        /// <summary>
	        /// status
	        /// </summary>
	        [XmlElement("status")]
	        public long Status { get; set; }
	
	        /// <summary>
	        /// step
	        /// </summary>
	        [XmlElement("step")]
	        public long Step { get; set; }
	
	        /// <summary>
	        /// update
	        /// </summary>
	        [XmlElement("update")]
	        public UpdateConfigActInfoDomain Update { get; set; }
	
	        /// <summary>
	        /// updateType
	        /// </summary>
	        [XmlElement("update_type")]
	        public string UpdateType { get; set; }
}

    }
}
