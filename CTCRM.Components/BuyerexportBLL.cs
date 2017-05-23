using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CTCRM.DAL;

namespace CTCRM.Components
{
    public  class BuyerexportBLL
    {
        public static int CheckEndStatus(string sellerId)
        {
            CTCRM.DAL.BuyerexportDAL export = new DAL.BuyerexportDAL();
            return export.CheckEndStatus(sellerId);
        }

        public static int InsertExport(string sellerId, string buyer_nick)
        {
            CTCRM.DAL.BuyerexportDAL export = new DAL.BuyerexportDAL();
            return export.InsertExport(sellerId, buyer_nick);
        }

        public static int UpdateExport(string sellerId,int status)
        {
            CTCRM.DAL.BuyerexportDAL export = new DAL.BuyerexportDAL();
            return export.UpdateExport(sellerId, status);
        }
        public static int UpdateExport(string buyer, string time, int status)
        {
            CTCRM.DAL.BuyerexportDAL export = new DAL.BuyerexportDAL();
            return export.UpdateExport(buyer, time, status);
        }
        //获取申请中的记录
        public static  DataTable GetBuyerExport()
        {
            CTCRM.DAL.BuyerexportDAL export = new DAL.BuyerexportDAL();
            return export.GetBuyerExport();
        }

        //获取全部申请的记录
        public static DataTable GetBuyerExportAll(string sellerId)
        {
            return BuyerexportDAL.GetBuyerExportAll( sellerId);
        }

        //插入SqlString
        public static int InsertBuyer_ExportSql(string sellerId, string sqlString)
        {
            return BuyerexportDAL.InsertBuyer_ExportSql(sellerId, sqlString);
        }

        //获取导出语句
        public static string GetExportSql(string sellerId)
        {
            return BuyerexportDAL.GetExportSql(sellerId);
        }
    }
}
