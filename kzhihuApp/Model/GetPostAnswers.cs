using System;
using System.Collections.Generic;


namespace kzhihuApp.Model
{
    public class GetPostAnswers
    {
        /// <summary>
        /// 本次获取文章数量（一般为10，也可能小于10）
        /// </summary>
        public string count { get; set; }

        /// <summary>
        /// 如此时间戳之前无文章，则error==”no result”
        /// </summary>
        public string error { get; set; }

        public List<Answers> answers { get; set; }


        public static GetPostAnswers LoadPostAnswers(DateTime time, PostsEnumType type)
        {
            string json =HttpHelper.GetUrltoHTML(string.Format("http://api.kzhihu.com/getpostanswers/{0}/{1}",time.ToString("yyyyMMdd"),type.ToString()));
            var dataInfo = JsonHelper.JsonDataToObject<GetPostAnswers>(json);
            return dataInfo;
        }
    }

    public class Answers
    {
        /// <summary>
        /// 文章id
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 答案摘要
        /// </summary>
        public string summary { get; set; }

        /// <summary>
        /// 问题id，8位数字
        /// </summary>
        public int questionid { get; set; }

        /// <summary>
        /// 答案id，8位数字
        /// </summary>
        public int answered { get; set; }

        /// <summary>
        /// 答主名称
        /// </summary>
        public string authorname { get; set; }

        /// <summary>
        /// 答主hash
        /// </summary>
        public string authorhash { get; set; }

        /// <summary>
        /// 答主头像url
        /// </summary>
        public string avatar{ get; set; }

        /// <summary>
        /// 赞同票数
        /// </summary>
        public int vote { get; set; }
    }
}
