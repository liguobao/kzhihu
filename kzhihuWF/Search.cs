
using kzhihuWF.BizModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kzhihuWF
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
           
        }

        private void Search_Load(object sender, EventArgs e)
        {
            var lstPost = BizPost.LoadBizPosts(DateTime.Now);
            string posts =string.Join("\r\n\n" ,lstPost.Select(p => p.Excerpt).ToList());
            txtContent.Text = posts;

            var lstPostAnswer = BizPostAnswers.LoadPostAnswers(DateTime.Now.AddDays(-1),PostsEnumType.Archive);
            string postanswers = string.Join("\r\n\n", lstPostAnswer.Select(p => p.Summary).ToList());
            txtContent.Text = txtContent.Text + postanswers;


            var lstUserInfo= BizSearchUserInfo.LoadUserInfo("伊宝宝");
            txtContent.Text = lstUserInfo[0].UserAvatarUrl;

        }
    }
}
