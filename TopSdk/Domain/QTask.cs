using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// QTask Data Structure.
    /// </summary>
    [Serializable]
    public class QTask : TopObject
    {
        /// <summary>
        /// json格式的字符串，包含跳转协议
        /// </summary>
        [XmlElement("action")]
        public string Action { get; set; }

        /// <summary>
        /// 附件的文件名
        /// </summary>
        [XmlElement("attachments")]
        public string Attachments { get; set; }

        /// <summary>
        /// 业务入口
        /// </summary>
        [XmlElement("biz_entry")]
        public string BizEntry { get; set; }

        /// <summary>
        /// 业务ID
        /// </summary>
        [XmlElement("biz_id")]
        public string BizId { get; set; }

        /// <summary>
        /// 点击业务号时的动作
        /// </summary>
        [XmlElement("biz_id_action")]
        public string BizIdAction { get; set; }

        /// <summary>
        /// 业务号的展示名称
        /// </summary>
        [XmlElement("biz_id_name")]
        public string BizIdName { get; set; }

        /// <summary>
        /// 与业务相关的对象。当前主要用于保存买家nick
        /// </summary>
        [XmlElement("biz_nick")]
        public string BizNick { get; set; }

        /// <summary>
        /// 业务参数
        /// </summary>
        [XmlElement("biz_param")]
        public string BizParam { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// biz_type的类型中文名
        /// </summary>
        [XmlElement("biz_type_str")]
        public string BizTypeStr { get; set; }

        /// <summary>
        /// 当前任务的评论数
        /// </summary>
        [XmlElement("comment_count")]
        public long CommentCount { get; set; }

        /// <summary>
        /// 新任务的内容
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 表示是否为本条记录接收人实际完成
        /// </summary>
        [XmlElement("finish_flag")]
        public long FinishFlag { get; set; }

        /// <summary>
        /// 任务完成标识, 0-一个人完成整个任务, 1-所有人完成整个任务完成，冗余任务元数据字段
        /// </summary>
        [XmlElement("finish_strategy")]
        public long FinishStrategy { get; set; }

        /// <summary>
        /// 任务创建时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

        /// <summary>
        /// gmt_create的数字格式
        /// </summary>
        [XmlElement("gmt_create_long")]
        public long GmtCreateLong { get; set; }

        /// <summary>
        /// 任务完成时间，格式：当前时间毫秒数
        /// </summary>
        [XmlElement("gmt_finished")]
        public string GmtFinished { get; set; }

        /// <summary>
        /// gmt_finished的数字格式
        /// </summary>
        [XmlElement("gmt_finished_long")]
        public long GmtFinishedLong { get; set; }

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
        /// 任务ID
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [XmlElement("is_deleted")]
        public long IsDeleted { get; set; }

        /// <summary>
        /// 任务备注
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 关联的任务元数据
        /// </summary>
        [XmlElement("meta")]
        public Top.Api.Domain.QTaskMetadata Meta { get; set; }

        /// <summary>
        /// 任务元id
        /// </summary>
        [XmlElement("metadata_id")]
        public long MetadataId { get; set; }

        /// <summary>
        /// 父任务的id
        /// </summary>
        [XmlElement("parent_task_id")]
        public long ParentTaskId { get; set; }

        /// <summary>
        /// 优先级，同任务元中的priority值，方便查询使用。
        /// </summary>
        [XmlElement("priority")]
        public long Priority { get; set; }

        /// <summary>
        /// 任务&ldquo;已读&rdquo;、&ldquo;未读&rdquo;状态，0：已读，1：未读
        /// </summary>
        [XmlElement("read_status")]
        public long ReadStatus { get; set; }

        /// <summary>
        /// 执行者用户昵称
        /// </summary>
        [XmlElement("receiver_nick")]
        public string ReceiverNick { get; set; }

        /// <summary>
        /// 执行者用户数字ID
        /// </summary>
        [XmlElement("receiver_uid")]
        public long ReceiverUid { get; set; }

        /// <summary>
        /// 到期提醒的方式。0-不提醒 1-pc和移动提醒 2-仅pc提醒 3-仅移动提醒。在查询类接口中，只需要传2或3即可，为1的数据都会包含在其中。
        /// </summary>
        [XmlElement("remind_flag")]
        public long RemindFlag { get; set; }

        /// <summary>
        /// 提醒时间
        /// </summary>
        [XmlElement("remind_time")]
        public string RemindTime { get; set; }

        /// <summary>
        /// remind_time的数字格式
        /// </summary>
        [XmlElement("remind_time_long")]
        public long RemindTimeLong { get; set; }

        /// <summary>
        /// 发起人nick
        /// </summary>
        [XmlElement("sender_nick")]
        public string SenderNick { get; set; }

        /// <summary>
        /// 发起人uid
        /// </summary>
        [XmlElement("sender_uid")]
        public long SenderUid { get; set; }

        /// <summary>
        /// 任务状态：0-未执行，1-执行中，2-执行完成，3-超时，4-取消，5-忽略
        /// </summary>
        [XmlElement("status")]
        public long Status { get; set; }

        /// <summary>
        /// 子业务类型
        /// </summary>
        [XmlElement("sub_biz_type")]
        public string SubBizType { get; set; }

        /// <summary>
        /// 子任务状态，由业务方自定义
        /// </summary>
        [XmlElement("sub_status")]
        public long SubStatus { get; set; }

        /// <summary>
        /// 任务标签
        /// </summary>
        [XmlElement("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// 同次操作相关的任务数
        /// </summary>
        [XmlElement("total_count")]
        public long TotalCount { get; set; }

        /// <summary>
        /// 语音附件的文件名
        /// </summary>
        [XmlElement("voice_file")]
        public string VoiceFile { get; set; }
    }
}
