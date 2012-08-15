using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic;
using FeelOfTravel.Logic.Common;

namespace FeelOfTravel.Controls
{
    public partial class TeaserViewControl : System.Web.UI.UserControl
    {
        private ITeaserService teaserService;

        public object DataSource
        {
            get { return rptTeaserView.DataSource; }
            set { rptTeaserView.DataSource = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            teaserService = CompositionRootHelper.GetCompositionRoot(Context).TeaserService;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        protected string GetArticleLink(Teaser teaser)
        {
            if (teaser != null)
            {
                return Page.GetHost() + "/PublicPages/ArticlePage.aspx?articleId=" + teaser.RelatedArticleId;
            }
            return string.Empty;
        }

        protected bool IsImageVisible(Teaser teaser)
        {
            return !string.IsNullOrEmpty(teaser.ImageLink);
        }

        protected void OnTeasersDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem is Teaser)
            {
                var teaser = e.Item.DataItem as Teaser;

                var relatedArticle = teaserService.GetLinkedArticle(teaser);
                if (relatedArticle == null)
                {
                    return;
                }

                var articleLink = (HyperLink)e.Item.FindControl("lnkArticleLink");
                var teaserImage = (Image)e.Item.FindControl("imgTeaser");
                var lblPreamble = (Label)e.Item.FindControl("lblPreamble");
                var lblPrice = (Label)e.Item.FindControl("lblPrice");

                articleLink.NavigateUrl = GetArticleLink(teaser);
                teaserImage.Visible = IsImageVisible(teaser);
                teaserImage.ImageUrl = teaser.ImageLink.FormatForHtml(Page.GetHost());
                lblPreamble.Text = teaser.Preamble;
                lblPrice.Text = NumberFormatter.GetFormat(relatedArticle.Price);
            }
        }
    }
}