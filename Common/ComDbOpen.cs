using System;
using System.Collections.Generic;
using System.Text;
using TTNI.Framework.Dao;
using TTNI.Framework.Data;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM.Common
{
    public class ComDbOpen : GenericDao
    {
        #region public static void DbOpen(IDBSession dbSession) 连接数据库

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="dbSession">数据源</param>
        public static void DbOpen(IDBSession dbSession)
        {
            try
            {
                // 创建连接
                dbSession.Open();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Configuration);
            }
        }

        #endregion
    }
}
