using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WangwangEserviceGroupmemberGetResponse.
    /// </summary>
    public class WangwangEserviceGroupmemberGetResponse : TopResponse
    {
        /// <summary>
        /// 组及其成员列表
        /// </summary>
        [XmlArray("group_member_list")]
        [XmlArrayItem("group_member")]
        public List<Top.Api.Domain.GroupMember> GroupMemberList { get; set; }

    }
}
