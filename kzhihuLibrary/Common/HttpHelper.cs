﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kzhihuLibrary
{
    /// <summary>
    /// HttpHelper类
    /// </summary>
    public class HttpHelper
    {
        public static string GetUrltoHtml(string Url, string type="UTF-8")
        {
            try
            {
                Url = Url.ToLower();

                System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
                // Get the response instance.
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.GetEncoding(type)))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}
