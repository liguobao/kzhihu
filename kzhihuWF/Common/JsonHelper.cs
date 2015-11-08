using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
/// <summary>
/// Json序列化和反序列化辅助类 
/// </summary>
public class JsonHelper
{
    /// <summary> 
    /// Json序列化 
    /// </summary> 
    public static string JsonSerializer<T>(T obj)
    {
        string jsonString = string.Empty;
        try
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                jsonString = Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        catch
        {
            jsonString = string.Empty;
        }
        return jsonString;
    }

    /// <summary> 
    /// Json反序列化
    /// </summary> 
    public static T JsonDeserialize<T>(string jsonString)
    {
        T obj = Activator.CreateInstance<T>();
        try
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(obj.GetType());//typeof(T)
                T jsonObject = (T)ser.ReadObject(ms);
                ms.Close();

                return jsonObject;
            }
        }
        catch
        {
            return default(T);
        }
    }

    // 将 DataTable 序列化成 json 字符串
    public static string DataTableToJson(DataTable dt)
    {
        if (dt == null || dt.Rows.Count == 0)
        {
            return "\"\"";
        }
        JavaScriptSerializer myJson = new JavaScriptSerializer();

        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        foreach (DataRow dr in dt.Rows)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (DataColumn dc in dt.Columns)
            {
                result.Add(dc.ColumnName, dr[dc].ToString());
            }
            list.Add(result);
        }
        return myJson.Serialize(list);
    }

    // 将对象序列化成 json 字符串
    public static string ObjectToJson(object obj)
    {
        if (obj == null)
        {
            return string.Empty;
        }
        JavaScriptSerializer myJson = new JavaScriptSerializer();

        return myJson.Serialize(obj);
    }

    // 将 json 字符串反序列化成对象
    public static object JsonToObject(string json)
    {
        if (string.IsNullOrEmpty(json))
        {
            return null;
        }
        JavaScriptSerializer myJson = new JavaScriptSerializer();

        return myJson.DeserializeObject(json);
    }

    // 将 json 字符串反序列化成对象
    public static T JsonToObject<T>(string json)
    {
        if (string.IsNullOrEmpty(json))
        {
            return default(T);
        }
        JavaScriptSerializer myJson = new JavaScriptSerializer();

        return myJson.Deserialize<T>(json);
    }


    public static T JsonDataToObject<T>(string json)
    {
        MemoryStream stream = new MemoryStream();
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));////youType是与Json格式对应的C#类
        StreamWriter wr = new StreamWriter(stream);
        wr.Write(json);  //tabJson是你需要转化的Json字符串
        wr.Flush();
        stream.Position = 0;
        Object obj = ser.ReadObject(stream);
        T t = (T)obj;
        return t;
    }


    public static object JsonToObject(string jsonString, object obj)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
        using (MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
        {
            return serializer.ReadObject(mStream);
        }

    }
}