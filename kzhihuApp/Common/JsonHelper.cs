using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
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