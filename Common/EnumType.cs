using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Common
{
   public class EnumType
    {  
       /// <summary>
        /// 会员级别
       /// </summary>
        public enum BuyerLevel
        {
            普通客户 = 1,
            高级会员 = 2,
            VIP会员 = 3,
            至尊VIP会员=4
        }

        public enum MsgStatus
        {
            任务执行成功 = 00,
            错误用户账户和密码 = 01,
            账户余额不足 = 02,
            发送时间不能小于当前时间 = 08
        }
    }
}
