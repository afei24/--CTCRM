using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Magic.Common.CSVHelper
{
    public interface IEntityObject
    {
        IEntityObject ReadEntity(string parseString);
        string WriteString();
        void SetWirelessDesc(string userNick, int curr, int total, string gender, string imageHandler, Func<string, Int64, string> genderImageCompleteCallBack);
    }
    public abstract class BaseEntityObject : IEntityObject
    {
        public abstract void SetWirelessDesc(string userNick, int curr, int total, string gender, string imageHandler, Func<string, Int64, string> genderImageCompleteCallBack);
        IEntityObject IEntityObject.ReadEntity(string parseString)
        {
            string[] array = parseString.Split('\t');
            var properties = this.GetType().GetProperties();
            Array.ForEach<PropertyInfo>(properties, (property) =>
            {
                var attribute = property.GetCustomAttributes(typeof(DescribeAttribute), false).FirstOrDefault() as DescribeAttribute;
                var value = Convert.ChangeType(array[attribute.Index], property.PropertyType);
                if (attribute != null)
                {
                    if (property.PropertyType == typeof(String))
                    {
                        var res = value.ToString().Replace("\"", "");
                        property.SetValue(this, res, null);
                    }
                }
                else
                {
                    property.SetValue(this, value, null);
                }
            });
            return this;
        }
        public string WriteString()
        {
            /*添加值*/
            List<DescribeAttribute> attributes = new List<DescribeAttribute>();
            var properties = this.GetType().GetProperties();
            Array.ForEach<PropertyInfo>(properties, (property) =>
            {
                var attribute = property.GetCustomAttributes(typeof(DescribeAttribute), false).FirstOrDefault() as DescribeAttribute;
                if (attribute != null)
                {
                    attribute.CurrValue = property.GetValue(this, null);
                    attributes.Add(attribute);
                }
            });
            return ParseString(attributes);
        }
        /// <summary>
        /// 将对象转换为String
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        private string ParseString(List<DescribeAttribute> attributes)
        {
            StringBuilder strBuilder = new StringBuilder();
            var orderByAttribute = attributes.OrderBy(x => x.Index).ToArray();
            Array.ForEach<DescribeAttribute>(orderByAttribute, (curr) =>
            {
                strBuilder.Append(curr.CurrValue + "\t");
            });
            return strBuilder.ToString();
        }

    }
    public interface ICSVHelper
    {
        List<T> ReadCSV<T>(Stream stream, Encoding enCoding) where T : IEntityObject, new();
        string WriteCSV<T>(List<T> obj, string gender, string imageHandler, Func<string, Int64, string> genderImageCompleteCallBack, string userNick) where T : IEntityObject, new();
    }
}
