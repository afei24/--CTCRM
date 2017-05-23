using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Odbc;
using System.Data;
using System.Text.RegularExpressions;
using System.Reflection;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
namespace Magic.Common.CSVHelper
{
    public class CSVHelper : ICSVHelper
    {
        /// <summary>
        /// 生成表
        /// </summary>
        /// <param name="stream"></param>
        public void GenderProperty(Stream stream)
        {
            string template = "[Describe(EnName = \"{0}\", Filed = \"{1}\", Index ={2})] public string {3} {{ get; set; }}\r\n";
            var i = 0;
            StreamReader reader = new StreamReader(stream);
            var result = string.Empty;
            while (reader.Peek() > -1)
            {
                var ress = reader.ReadLine();
                if (i == 1)
                {
                    string[] res = ress.Split('\t');
                    var j = 0;
                    foreach (var item in res)
                    {
                        var filed = string.Empty;
                        if (item.Contains('_'))
                        {
                            string[] arr = item.Split('_');
                            foreach (string item1 in arr)
                            {
                                filed = FormatProperty(item1);
                            }
                        }
                        else
                        {
                            filed = FormatProperty(item);
                        }
                        var str = string.Format(template, item, item, j, filed);
                        result += str;
                        j++;
                    }
                }
                i++;
            }
        }
        private const string parrent = "(\\w)(\\w+)";
        public string FormatProperty(string parseString)
        {
            Match math = Regex.Match(parseString, parrent);
            return math.Groups[1].Value.ToUpper() + math.Groups[2].Value.ToLower();
        }
        private void SetColumnLength(string columnString)
        {
            if (string.IsNullOrEmpty(columnString)) ColumnLenth = 0;
            ColumnLenth = columnString.Split('\t').Count();
        }
        public int ColumnLenth { get; set; }
        public List<T> ReadCSV<T>(System.IO.Stream stream, Encoding enCoding) where T : IEntityObject, new()
        {
            List<T> list = new List<T>();

            using (StreamReader reader = new StreamReader(stream, Encoding.Default))
            {
                var i = -1;
                StringBuilder stringResult = new StringBuilder();
                while (reader.Peek() > -1)
                {
                    i++;
                    if (i < 3)
                    {
                        if (i == 2)
                            SetColumnLength(reader.ReadLine());
                        else
                            reader.ReadLine();
                        continue;
                    };
                    stringResult.Append(reader.ReadLine());
                    if (stringResult.ToString().Split('\t').Count() == ColumnLenth)
                    {
                        T currObject = new T();
                        Match math = Regex.Match(stringResult.ToString(), "(.*?\\t){" + (ColumnLenth - 1).ToString() + "}");
                        var ress = math.Value;
                        var index = stringResult.Remove(0, ress.Length);
                        var res = (T)currObject.ReadEntity(ress);
                        list.Add(res);
                    }
                }
            }
            return list;
        }
        private const string version = "version 1.00";
        public string WriteCSV<T>(List<T> objs, string gender, string imageHandler, Func<string, Int64, string> gendeImageCompleteCallBack, string userNick) where T : IEntityObject, new()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(version + "\n");
            strBuilder.Append(WriteColumnName(typeof(T)));
            for (int i = 0; i < objs.Count; i++)
            {
                try
                {

                    objs[i].SetWirelessDesc(userNick, i, objs.Count, gender, imageHandler, gendeImageCompleteCallBack);
                    var genderString = objs[i].WriteString();
                    genderString = genderString.Remove(genderString.LastIndexOf('\t'));
                    strBuilder.Append(genderString + "\n");
                }
                catch (Exception ex)
                {
                    continue;
                    //ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                }
            }


            return strBuilder.ToString();
        }

        private string WriteColumnName(Type type)
        {
            StringBuilder fieldStrBuilder = new StringBuilder();
            StringBuilder columnNameStrBuilder = new StringBuilder();
            Array.ForEach<PropertyInfo>(type.GetProperties(), (property) =>
            {
                var attribute = property.GetCustomAttributes(typeof(DescribeAttribute), false).FirstOrDefault() as DescribeAttribute;
                if (attribute != null)
                {
                    fieldStrBuilder.Append(attribute.Filed + "\t");
                    columnNameStrBuilder.Append(attribute.EnName + "\t");
                }

            });
            fieldStrBuilder.Append("\n");
            columnNameStrBuilder.Append("\n");
            fieldStrBuilder.Append(columnNameStrBuilder);
            return fieldStrBuilder.ToString();
        }
    }
}
