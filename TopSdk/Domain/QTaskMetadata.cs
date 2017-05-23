using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// QTaskMetadata Data Structure.
    /// </summary>
    [Serializable]
    public class QTaskMetadata : TopObject
    {
        /// <summary>
        /// 点击动作的协议
        /// </summary>
        [XmlElement("action")]
        public string Action { get; set; }

        /// <summary>
        /// 轻任务附件信息，userId_timestamp_随机字符串，例如：23434_1234458623_seresfto
        /// </summary>
        [XmlElement("attachments")]
        public string Attachments { get; set; }

        /// <summary>
        /// 我的安排的任务上的提醒时间
        /// </summary>
        [XmlElement("biz_remind_time")]
        public string BizRemindTime { get; set; }

        /// <summary>
        /// 是biz_remind_time的数字格式
        /// </summary>
        [XmlElement("biz_remind_time_long")]
        public long BizRemindTimeLong { get; set; }

        /// <summary>
        /// 来源系统ID
        /// </summary>
        [XmlElement("biz_sys_id")]
        public long BizSysId { get; set; }

        /// <summary>
        /// 任务在来源系统的类型, 这个是业务系统的自定义类型
        /// </summary>
        [XmlElement("biz_sys_task_type")]
        public long BizSysTaskType { get; set; }

        /// <summary>
        /// 接收的任务类型，所有相关的任务的类型一致时有效。当任务类型不一致时为diff
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// biztype的中文名
        /// </summary>
        [XmlElement("biz_type_str")]
        public string BizTypeStr { get; set; }

        /// <summary>
        /// 当前任务的评论数
        /// </summary>
        [XmlElement("comment_count")]
        public long CommentCount { get; set; }

        /// <summary>
        /// 任务摘要内容
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 任务结束时间，格式：当前时间毫秒数
        /// </summary>
        [XmlElement("end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// end_time的数字格式
        /// </summary>
        [XmlElement("end_time_long")]
        public long EndTimeLong { get; set; }

        /// <summary>
        /// 完成的任务数。如果完成策略是只需要1个人完成的，则只要一个人完成就会返回总任务条数。如果是所有人都要完成的，则会返回实际完成条数。
        /// </summary>
        [XmlElement("finish_count")]
        public long FinishCount { get; set; }

        /// <summary>
        /// 任务完成标识： 0表示只要有一个人完成任务即可，1表示所有人需要各自都完成任务
        /// </summary>
        [XmlElement("finish_strategy")]
        public long FinishStrategy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// gmt_create的数字格式
        /// </summary>
        [XmlElement("gmt_create_long")]
        public long GmtCreateLong { get; set; }

        /// <summary>
        /// 任务更新时间
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// gmt_modified的数字格式
        /// </summary>
        [XmlElement("gmt_modified_long")]
        public long GmtModifiedLong { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 任务元备注
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 优先级，0低，1中，2高
        /// </summary>
        [XmlElement("priority")]
        public long Priority { get; set; }

        /// <summary>
        /// 任务的接收人
        /// </summary>
        [XmlElement("receiver")]
        public string Receiver { get; set; }

        /// <summary>
        /// 提醒标志位： 0表示不需要提醒，1表示需要状态变更提醒
        /// </summary>
        [XmlElement("reminder_flag")]
        public long ReminderFlag { get; set; }

        /// <summary>
        /// 发起者用户昵称
        /// </summary>
        [XmlElement("sender_nick")]
        public string SenderNick { get; set; }

        /// <summary>
        /// 发起者用户数字ID
        /// </summary>
        [XmlElement("sender_uid")]
        public long SenderUid { get; set; }

        /// <summary>
        /// 任务开始时间，格式：当前时间毫秒数
        /// </summary>
        [XmlElement("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// start_time的数字格式
        /// </summary>
        [XmlElement("start_time_long")]
        public long StartTimeLong { get; set; }

        /// <summary>
        /// 0为未完成，2为完成，4为取消
        /// </summary>
        [XmlElement("status")]
        public long Status { get; set; }

        /// <summary>
        /// 与此任务元相关的任务数
        /// </summary>
        [XmlElement("task_count")]
        public long TaskCount { get; set; }

        /// <summary>
        /// 任务标题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 同次操作的任务元数
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

        /// <summary>
        /// 语音备注的文件名
        /// </summary>
        [XmlElement("voice_file")]
        public string VoiceFile { get; set; }
    }
}
