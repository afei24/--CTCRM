using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CTCRM.Common
{
   public class EXCELHelper
    {
       public static DataSet ExcelToDS(string Path)
       {
           string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
           OleDbConnection conn = new OleDbConnection(strConn);
           conn.Open();
           string strExcel = "";
           OleDbDataAdapter myCommand = null;
           DataSet ds = null;
           strExcel = "select * from [短信账户$]";
           myCommand = new OleDbDataAdapter(strExcel, strConn);
           ds = new DataSet();
           myCommand.Fill(ds, "table1");
           return ds;
       }

       public static DataSet ExcelToDSForBatchShippingForExcel2003(string Path)
       {
           string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + Path + ";Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'"; //此连接只能操作Excel2007之前(.xls)文件
           OleDbConnection conn = new OleDbConnection(strConn);
           conn.Open();
           string strExcel = "";
           OleDbDataAdapter myCommand = null;
           DataSet ds = null;
           strExcel = "select * from [Sheet1$]";
           myCommand = new OleDbDataAdapter(strExcel, strConn);
           ds = new DataSet();
           myCommand.Fill(ds, "table1");
           return ds;
       }
       public static DataSet ExcelToDSForBatchShippingForExcel2012(string Path)
       {
           string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + Path + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'"; //此连接可以操作.xls与.xlsx文件 (支持Excel2003 和 Excel2007 的连接字符串)
           //备注： "HDR=yes;"是说Excel文件的第一行是列名而不是数据，"HDR=No;"正好与前面的相反。
           //      "IMEX=1 "如果列中的数据类型不一致，使用"IMEX=1"可必免数据类型冲突。 
           OleDbConnection conn = new OleDbConnection(strConn);
           conn.Open();
           string strExcel = "";
           OleDbDataAdapter myCommand = null;
           DataSet ds = null;
           strExcel = "select * from [Sheet1$]";
           myCommand = new OleDbDataAdapter(strExcel, strConn);
           ds = new DataSet();
           myCommand.Fill(ds, "table1");
           return ds;
       } 

    }
}
