using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCRM.Entity
{
    //20160916 yao c
    public class LogsticDetailTrace
    {
        string action = string.Empty;
        /// <summary>
        /// 物流状态
        /// CREATE:物流订单创建,
        /// CONSIGN:卖家发货, 
        /// GOT:揽收成功, 
        /// ARRIVAL:进站, 
        /// DEPARTURE:出站, 
        /// SIGNED:签收成功, 
        /// SENT_SCAN:派件扫描, 
        /// FAILED:签收失败/拒签, 
        /// LOST:丢失, SENT_CITY:到货城市, 
        /// TO_EMS:订单转给EMS, 
        /// OTHER:其他事件/操作 
        /// </summary>
        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        string company_name = string.Empty;
        /// <summary>
        /// 物流公司名称
        /// </summary>
        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }
        
        string desc = string.Empty;
        /// <summary>
        /// 物流流转信息
        /// </summary>
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        string out_side = string.Empty;
        /// <summary>
        /// 运单号
        /// </summary>
        public string Out_side
        {
            get { return out_side; }
            set { out_side = value; }
        }

        string tid = string.Empty;
        /// <summary>
        /// 交易订单
        /// </summary>
        public string Tid
        {
            get { return tid; }
            set { tid = value; }
        }

        string time = string.Empty;
        /// <summary>
        /// 处理时间
        /// </summary>
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
