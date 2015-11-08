using kzhihuLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kzhihuLibrary.BizModel
{
    public class BizSearchUserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>

        public string ZhiHuUserID { get; set; }


        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户hash (用于获取用户detail)
        /// </summary>
        public string UserHash { get; set; }

        /// <summary>
        /// 用户头像url
        /// </summary>
        public string UserAvatarUrl { get; set; }

        /// <summary>
        /// 用户签名
        /// </summary>
        public string UserSignature { get; set; }

        /// <summary>
        /// 回答+专栏数量
        /// </summary>
        public int UserAnswer { get; set; }

        /// <summary>
        /// 赞同数量
        /// </summary>
        public int UserAgree { get; set; }

        /// <summary>
        /// 被关注数量
        /// </summary>
        public int UserFollower { get; set; }


        public BizSearchUserInfo()
        {

        }


        public BizSearchUserInfo(UserInfo dataInfo)
        {
            UserAgree = dataInfo.agree;
            UserAnswer = dataInfo.answer;
            UserAvatarUrl = dataInfo.avatar;
            UserFollower = dataInfo.follower;
            UserHash = dataInfo.hash;
            UserName = dataInfo.name;
            ZhiHuUserID = dataInfo.id;
            UserSignature = dataInfo.signature;
        }



        public static List<BizSearchUserInfo>  ConvertToBiz(SearchUser dataInfo)
        {
            var lstUserInfo = new List<BizSearchUserInfo>();
            if (string.IsNullOrEmpty(dataInfo.error)&&dataInfo.users!=null)
            {
                lstUserInfo.AddRange(dataInfo.users.Select(u =>new BizSearchUserInfo(u)));
            }
            return lstUserInfo;
        }

        public static List<BizSearchUserInfo> LoadUserInfo(string name)
        {
            var dataInfo = SearchUser.LoadSearchUserInfo(name);
            return ConvertToBiz(dataInfo);
        }


    }
}
