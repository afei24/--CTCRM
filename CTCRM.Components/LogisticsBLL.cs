﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.DAL;
using CTCRM.Entity;

namespace CTCRM.Components
{
    public class LogisticsBLL
    {

        /// <summary>
        /// 添加物流信息到数据库
        /// </summary>
        /// <param name="logstic"></param>
        /// <returns></returns>
        public static bool AddLogistics(LogsticDetailTrace logstic)
        {
            return CTCRM.DAL.LogisticsDAL.AddLogistics(logstic);
        }


        /// <summary>
        /// 查询该交易订单的物流数据是否已经存在
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static bool TidIsExist(string tid)
        {
            return CTCRM.DAL.LogisticsDAL.TidIsExist(tid);

        }

        /// <summary>
        /// 更新物流信息
        /// </summary>
        /// <param name="logstic"></param>
        /// <returns></returns>
        public static bool updateLogistics(LogsticDetailTrace logstic)
        {
            return CTCRM.DAL.LogisticsDAL.updateLogistics(logstic);
        }

        /// <summary>
        /// 获取交易的物流状态
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static string getLogisticsStatusByTid(string tid)
        {
            return CTCRM.DAL.LogisticsDAL.getLogisticsStatusByTid(tid);
        }

       

    }
}
