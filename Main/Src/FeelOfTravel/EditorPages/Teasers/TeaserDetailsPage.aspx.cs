using System;
using System.Collections.Generic;
using System.Linq;

using AjaxControlToolkit;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic;
using FeelOfTravel.Logic.Common;
using FeelOfTravel.Model.Utils;

namespace FeelOfTravel.EditorPages.Teasers
{
    public partial class TeaserDetailsPage : System.Web.UI.Page
    {
        private const string BannerKey = "banner";
        public const string ImagePath = @"\UploadedImages\Teasers\";

        private ITeaserService teaserService;

        private IArticleService articleService;

        private int TeaserIdInRequest
        {
            get
            {
                const string TEASER_ID_KEY = "teaserId";

                if (Page.Request[TEASER_ID_KEY] == null) return 0;

                int tmpId;
                if (!int.TryParse(Page.Request[TEASER_ID_KEY], out tmpId))
                {
                    return 0;
                }

                return tmpId;
            }
        }

        private int ParentArticleIdInRequest
        {
            get
            {
                const string ARTICLE_ID_KEY = "articleId";

                if (Page.Request[ARTICLE_ID_KEY] == null)
                {
                    return -1;
                }

                int tmpId;
                if (!int.TryParse(Page.Request[ARTICLE_ID_KEY], out tmpId))
                {
                    throw new PageException("You passed wrong articleId");
                }

                return tmpId;
            }
        }

        private string RelativeImagePath
        {
            get { return Session[BannerKey] != null ? (string)Session[BannerKey] : null; }
            set
            {
                // Save into session, because during ajax upload contol event we can't use ViewState for storing data.
                Session[BannerKey] = value;
            }
        }

        protected string GetUploadCompleteCallbackName()
        {
            return "uploadCompleteFunc_" + ClientID;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            teaserService = CompositionRootHelper.GetCompositionRoot(Context).TeaserService;
            articleService = CompositionRootHelper.GetCompositionRoot(Context).ArticleService;

            if (!IsPostBack)
            {
                afuImageUpload.OnClientUploadComplete = GetUploadCompleteCallbackName();

                if (TeaserIdInRequest != 0)
                {
                    BindTeaserDetails(TeaserIdInRequest);
                }
                else if (ParentArticleIdInRequest == 0)
                {
                    Response.Redirect("~/EditorPages/Teasers/TeaserManagementPage.aspx");
                }

                txtArticleLink.BackColor = System.Drawing.Color.Khaki;
            }
        }

        private void BindTeaserDetails(int teaserId)
        {
            var teaser = teaserService.Repository.Read(teaserId);

            var article = teaserService.GetLinkedArticle(teaser);
            if (article == null)
            {
                throw new Exception("Нет статьи, связанной с тизером");
            }
            RelativeImagePath = teaser.ImageLink;

            imgBanner.ImageUrl = RelativeImagePath.FormatForHtml(Page.GetHost());
            txtTeaserPreamble.Text = teaser.Preamble;
            txtImageFileName.Text = ExtractImageFileName(teaser.ImageLink);
            txtArticleLink.Text = string.Format("[{0}]{1}", article.Id, article.Header.SafeCrop(40));
        }

        protected void BtnSaveTeaserClick(object sender, EventArgs e)
        {
            try
            {
                UpdateTeaserUnsafe(TeaserIdInRequest);
                RelativeImagePath = null;

                labTeaserStatus.Text = "Тизер сохранен";
            }
            catch (Exception ex)
            {
                labTeaserStatus.Text = ex.Message;
            }
        }

        private void UpdateTeaserUnsafe(int teaserId)
        {
            Teaser teaser;
            if (teaserId != 0)
            {
                teaser = teaserService.Repository.Read(teaserId);
            }
            else
            {
                if (ParentArticleIdInRequest <= 0)
                {
                    return;
                }
                var parentArticle = articleService.Repository.Read(ParentArticleIdInRequest);

                teaser = new Teaser { RelatedArticleId = parentArticle.Id };
            }

            teaser.ImageLink = RelativeImagePath;
            teaser.Preamble = txtTeaserPreamble.Text;

            teaserService.Repository.Update(teaser);
        }

        protected void AfuImageUpload_OnUploadedComplete(object sender, AsyncFileUploadEventArgs ea)
        {
            if (ea.State == AsyncFileUploadState.Success)
            {
                var filename = System.IO.Path.GetFileName(afuImageUpload.FileName);
                txtImageFileName.Text = filename;

                var mappedPath = Server.MapPath("~/UploadedImages/Teasers/") + filename;
                afuImageUpload.SaveAs(mappedPath);

                RelativeImagePath = MakeRelativeImagePath(filename);
            }
        }

        private static string MakeRelativeImagePath(string fileName)
        {
            return ImagePath + fileName;
        }

        private static string ExtractImageFileName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }

            var pos = ImagePath.Length;
            return pos < path.Length ? path.Substring(pos) : path;
        }
    }
}