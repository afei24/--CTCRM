using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractLotteryactivityRegisterResponse.
    /// </summary>
    public class AlibabaInteractLotteryactivityRegisterResponse : TopResponse
    {
        /// <summary>
        /// 接口返回model
        /// </summary>
        [XmlElement("result")]
        public ResultDomain Result { get; set; }

	/// <summary>
/// ActivityLotteryWriteResultDomain Data Structure.
/// </summary>
[Serializable]
public class ActivityLotteryWriteResultDomain : TopObject
{
	        /// <summary>
	        /// isv活动的id
	        /// </summary>
	        [XmlElement("activity_id")]
	        public long ActivityId { get; set; }
	
	        /// <summary>
	        /// isv活动url
	        /// </summary>
	        [XmlElement("h5_url")]
	        public string H5Url { get; set; }
}

	/// <summary>
/// ModulemapDomain Data Structure.
/// </summary>
[Serializable]
public class ModulemapDomain : TopObject
{
	        /// <summary>
	        /// false
	        /// </summary>
	        [XmlElement("empty")]
	        public bool Empty { get; set; }
}

	/// <summary>
/// ResultDomain Data Structure.
/// </summary>
[Serializable]
public class ResultDomain : TopObject
{
	        /// <summary>
	        /// 返回的数据
	        /// </summary>
	        [XmlElement("data")]
	        public ActivityLotteryWriteResultDomain Data { get; set; }
	
	        /// <summary>
	        /// 错误码
	        /// </summary>
	        [XmlElement("err_code")]
	        public string ErrCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("err_msg")]
	        public string ErrMsg { get; set; }
	
	        /// <summary>
	        /// xxx
	        /// </summary>
	        [XmlElement("module_map")]
	        public ModulemapDomain ModuleMap { get; set; }
	
	        /// <summary>
	        /// 注册抽奖活动失败
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
	
	        /// <summary>
	        /// 方便追踪请求的唯一标识
	        /// </summary>
	        [XmlElement("trace_id")]
	        public string TraceId { get; set; }
}

    }
}
