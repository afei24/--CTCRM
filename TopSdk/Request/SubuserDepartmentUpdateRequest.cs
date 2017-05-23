using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.subuser.department.update
    /// </summary>
    public class SubuserDepartmentUpdateRequest : BaseTopRequest<Top.Api.Response.SubuserDepartmentUpdateResponse>
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public Nullable<long> DepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 父部门ID 如果是最高部门则传入0
        /// </summary>
        public Nullable<long> ParentId { get; set; }

        /// <summary>
        /// 主账号用户名
        /// </summary>
        public string UserNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.subuser.department.update";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("department_id", this.DepartmentId);
            parameters.Add("department_name", this.DepartmentName);
            parameters.Add("parent_id", this.ParentId);
            parameters.Add("user_nick", this.UserNick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("department_id", this.DepartmentId);
            RequestValidator.ValidateRequired("user_nick", this.UserNick);
        }

        #endregion
    }
}
