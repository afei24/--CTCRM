using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ZMarketing.Json
{
    public class JsonHelper
    {
        /// <summary>
        /// 格式化成Json字符串
        /// </summary>
        /// <param name="JsonObj">需要格式化的对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJson<T>(T JsonObj)
        {
            // 首先，当然是JSON序列化
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            
            // 定义一个stream用来存发序列化之后的内容
            MemoryStream ms = new MemoryStream();
            ms.Position = 0;
            serializer.WriteObject(ms, JsonObj);
            string json = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            ms.Dispose();
            return json;
        }

        /// <summary>
        /// Json反序列化,用于接收客户端Json后生成对应的对象
        /// </summary>
        public static T FromJsonTo<T>(string jsonString)
        {

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

            T jsonObject = (T)ser.ReadObject(ms);

            ms.Close();

            return jsonObject;

        }


    }
}
