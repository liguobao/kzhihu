using kzhihuWF.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace kzhihuWF.BizModel
{
    class BizPostAnswers
    {
        #region 属性

        /// <summary>
        /// 文章id
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 答案摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 问题id，8位数字
        /// </summary>
        public int QuestionID { get; set; }

        /// <summary>
        /// 答案id，8位数字
        /// </summary>
        public int Answered { get; set; }

        /// <summary>
        /// 答主名称
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 答主hash
        /// </summary>
        public string AuthorHash { get; set; }

        /// <summary>
        /// 答主头像url
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 赞同票数
        /// </summary>
        public int Vote { get; set; }
        #endregion

        public BizPostAnswers()
        {

        }

        public BizPostAnswers(Answers dataIndo)
        {
            Time =Convert.ToDateTime(dataIndo.time);
            Title = dataIndo.title;
            Answered = dataIndo.answered;
            AuthorName = dataIndo.authorname;
            AuthorHash = dataIndo.authorhash;
            Avatar = dataIndo.avatar;
            QuestionID = dataIndo.questionid;
            Summary = dataIndo.summary;


        }


        /// <summary>
        /// mode 转换成biz
        /// </summary>
        /// <param name="getPostAnswers"></param>
        /// <returns></returns>
        public static List<BizPostAnswers> ConvertToBizPostAnswers(GetPostAnswers getPostAnswers)
        {
            List<BizPostAnswers> lstPostAnswers = new List<BizPostAnswers>();
            if (string.IsNullOrEmpty(getPostAnswers.error)&& getPostAnswers.answers!=null)
            {
                lstPostAnswers.AddRange(getPostAnswers.answers.Select(a=>new BizPostAnswers(a)));
            }
            return lstPostAnswers;
        }

        /// <summary>
        /// 获取单篇文章的答案列表
        /// </summary>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<BizPostAnswers> LoadPostAnswers(DateTime time, PostsEnumType type)
        {
            var dataInfo = GetPostAnswers.LoadPostAnswers(time, type);
            return ConvertToBizPostAnswers(dataInfo);
        }

    }
}
