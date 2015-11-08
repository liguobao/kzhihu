
using System;
using System.Collections.Generic;

namespace kzhihuWF.Model
{
    /// <summary>
    /// http://api.kzhihu.com/getposts 获取“看知乎”类别
    /// </summary>
    public class GetPosts
    {
        /// <summary>
        /// 本次获取文章数量（一般为10，也可能小于10）
        /// </summary>
        public string count { get; set; }

        /// <summary>
        /// 如此时间戳之前无文章，则error==”no result”
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// 文章信息列表
        /// </summary>
        public List<Post> posts { get; set; }

        /// <summary>
        /// 加载GetPosts信息
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static GetPosts LoadGetPosts(DateTime time)
        {
            string json = HttpHelper.GetUrltoHtml("http://api.kzhihu.com/getposts/" + CommonHelper.UnixTicks(time));
            var dataInfo = JsonHelper.JsonDataToObject<GetPosts>(json);
            return dataInfo;
        }

    }


    /// <summary>
    /// ，文章信息列表
    /// </summary>
    public class Post
    {
        /// <summary>
        /// 发表日期（yyyy-mm-dd）
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 文章名称（yesterday, recent, archive）
        /// </summary>

        public string name { get; set; }

        /// <summary>
        /// 抬头图url
        /// </summary>
        public string pic { get; set; }

        /// <summary>
        /// 发表时间戳
        /// </summary>
        public int publishtime { get; set; }

        /// <summary>
        /// 文章包含答案数量
        /// </summary>
        public int count { get; set; }


        /// <summary>
        /// excerpt(string)，摘要文字
        /// </summary>
        public string excerpt { get; set; }

    }
}
