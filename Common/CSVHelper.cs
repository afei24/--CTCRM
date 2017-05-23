using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace CTCRM.Common
{
    public  class CSVHelper
    {

        private string path;
        private string fileName;
    ///<summary>
    /// z构造函数
    ///</summary>
    public CSVHelper(string filePath, string fileName)
    {
        this.path = filePath;
        this.fileName = fileName;
    }

    ///<summary>
    /// 从Csv中读取数据
    ///</summary>
    ///<returns></returns>
    public DataTable Read()
    {
        return Read(null);
    }
    ///<summary>
    /// 通过文件流的方式来读取CSV文件，默认第一列为标题列，列之间用逗号分隔
    ///</summary>
    ///<param name="files"></param>
    ///<returns></returns>
    public DataTable ReadCsvFileToTable()
    {
        return ReadCsvFileToTable(true, ',');
    }
    ///<summary>
    /// 通过文件流的方式来读取CSV文件，默认列之间用逗号分隔
    ///</summary>
    ///<param name="files">文件名称</param>
    ///<param name="HeadYes">第一行是否为列标题</param>
    ///<returns></returns>
    public DataTable ReadCsvFileToTable(bool HeadYes)
    {
        return ReadCsvFileToTable(HeadYes, ',');
    }
    ///<summary>
    /// 通过文件流的方式来读取CSV文件
    ///</summary>
    ///<param name="files">文件名称</param>
    ///<param name="HeadYes">第一行是否为列标题</param>
    ///<param name="span">分隔符</param>
    ///<returns></returns>
    public DataTable ReadCsvFileToTable(bool HeadYes, char span)
    {
        //文件路径和文件名
        string files = path + fileName;
        DataTable dt = new DataTable();
        StreamReader fileReader = new StreamReader(files, Encoding.Default);
        try
        {
            //是否为第一行（如果HeadYes为TRUE，则第一行为标题行）
            int lsi = 0;
            //列之间的分隔符
            char cv = span;
            while (fileReader.EndOfStream == false)
        {
            string line = fileReader.ReadLine();
            string[] y = line.Split(cv);
            //第一行为标题行
            if (HeadYes == true)
                {
            //第一行
            if (lsi == 0)
                    {
            for (int i = 0; i < y.Length; i++)
                        {
                            dt.Columns.Add(y[i].Trim().ToString());
                        }
                        lsi++;
                    }
            //从第二列开始为数据列
            else
                    {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < y.Length; i++)
                        {
                            dr[i] = y[i].Trim();
                        }
                        dt.Rows.Add(dr);
                    }
            }
        //第一行不为标题行
        else
            {
        if (lsi == 0)
                {
        for (int i = 0; i < y.Length; i++)
                    {
                        dt.Columns.Add("Col" + i.ToString());
                    }
                    lsi++;
                }
        DataRow dr = dt.NewRow();
        for (int i = 0; i < y.Length; i++)
                {
                    dr[i] = y[i].Trim();
                }
                dt.Rows.Add(dr);
            }
        }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            fileReader.Close();
            fileReader.Dispose();
        }
        return dt;
    }

    ///<summary>
    /// 从csv中读取数据
    ///</summary>
    ///<param name="colNames">列名列表，可为空</param>
    ///<returns></returns>
    private DataTable Read(string[] colNames)
    {
        string sql = CreateSql(colNames);
        return ExecuteTable(sql);
    }

    ///<summary>
    /// 通过执行sql语句，从Csv中读取数据
    ///</summary>
    ///<param name="sql">sql语句</param>
    ///<returns></returns>
    private DataTable ExecuteTable(string sql)
    {
        DataTable table = new DataTable();
        using (OleDbConnection connection = new OleDbConnection(GetConnString(true)))
        {
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = sql;

            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(table);
        }
        return table;
    }

    #region 私有方法

    private string CreateSql(string[] colNames)
    {
        string cols = "*";
        if (null != colNames && colNames.Length > 0)
        {
            StringBuilder colList = new StringBuilder();
            for (int i = 0; i < colNames.Length - 1; i++)
            {
                colList.AppendFormat("[{0}],", colNames[i]);
            }
            colList.AppendFormat("[{0}]", colList[colList.Length]);
            cols = colList.ToString();
        }
        return string.Format("select {0} from {1}", cols, fileName);
    }

    private string GetConnString(bool IsHeaderRow)
    {
         return string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='Text;FMT=Delimited; HDR={0}';data source={1}", IsHeaderRow ? "Yes" : "No", path);
    }

    #endregion
   }
}


