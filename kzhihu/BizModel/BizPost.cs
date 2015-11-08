using System;
using System.Collections.Generic;
using System.Linq;
using kzhihuWF.Model;

namespace kzhihuWF.BizModel
{
    public class BizPost
    {

        #region 公开属性
        /// <summary>
        /// 发表日期（yyyy-mm-dd）
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 文章名称（yesterday, recent, archive）
        /// </summary>

        public PostsEnumType PostsTyp { get; set; }

        /// <summary>
        /// 抬头图url
        /// </summary>
        public string PicURL { get; set; }

        /// <summary>
        /// 发表时间戳
        /// </summary>
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// 文章包含答案数量
        /// </summary>
        public int PostsCount { get; set; }


        /// <summary>
        /// excerpt(string)，摘要文字
        /// </summary>
        public string Excerpt { get; set; }

        #endregion


        #region 方法


        #endregion
        public BizPost()
        {

        }

        public BizPost(Post dataInfo)
        {
            var date =  DateTime.Now;
            DateTime.TryParse(dataInfo.date,out date);
            CreateDate = date;
            var type = PostsEnumType.Archive;
            Enum.TryParse<PostsEnumType>(dataInfo.name,out type);
            PostsTyp = type;
            PicURL = dataInfo.pic;
           
            PublishTime = CommonHelper.JsonDateToDateTime(dataInfo.publishtime);
            PostsCount = dataInfo.count;
            Excerpt = dataInfo.excerpt;
        }

        /// <summary>
        /// GetPosts API数据转Posts
        /// </summary>
        /// <param name="getPosts"></param>
        /// <returns></returns>
        public static List<BizPost> ConvertToBizPosts(GetPosts getPosts)
        {
            var lstPosts = new List<BizPost>();
            if(string.IsNullOrEmpty(getPosts.error)&&getPosts.posts!=null)
            {
               lstPosts.AddRange(getPosts.posts.Select(p => new BizPost(p)));
            }
            return lstPosts;
        }

        /// <summary>
        /// 获取某个日期的Posts
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static List<BizPost> LoadBizPosts(DateTime time)
        {
            var getPosts = GetPosts.LoadGetPosts(time);
            return ConvertToBizPosts(getPosts);
        }



    }
}
