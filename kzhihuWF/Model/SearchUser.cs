using System.Collections.Generic;


namespace kzhihuWF.Model
{
    public class SearchUser
    {
        public int count { get; set; }

        public string error { get; set; }

        public List<UserInfo> users { get; set; }


        public static SearchUser LoadSearchUserInfo(string name)
        {
            string json = HttpHelper.GetUrltoHtml("http://api.kzhihu.com/searchuser/"+name);
            return JsonHelper.JsonDataToObject<SearchUser>(json);
        }

    }

    public class UserInfo
    {
        public string id { get; set; }

        public string name { get; set; }


        public string hash { get; set; }

        public string avatar { get; set; }


        public string signature { get; set; }


        public int answer { get; set; }


        public int agree { get; set; }


        public int follower { get; set; }
    }
}
