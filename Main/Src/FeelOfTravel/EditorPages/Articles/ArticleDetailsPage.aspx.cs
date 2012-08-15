using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic;
using FeelOfTravel.Logic.Common;

namespace FeelOfTravel.EditorPages.Articles
{
    public partial class ArticleDetailsPage : System.Web.UI.Page
    {
        private const string ArticleIdKey = "articleId";

        private IArticleService articleService;

        private int CurrentArticleId
        {
            get
            {
                return ViewState["currentArticleId"] != null
                    ? PageHelper.GetIdInSpecialWay(ViewState["currentArticleId"].ToString())
                    : 0;
            }

            set
            {
                ViewState["currentArticleId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            articleService = CompositionRootHelper.GetCompositionRoot(Context).ArticleService;

            if (!IsPostBack)
            {
                ddlArticleType.DataSource = articleService.GetArticleTypes();
                ddlArticleType.DataValueField = "Id";
                ddlArticleType.DataTextField = "Description";

                ddlArticleType.DataBind();

                CurrentArticleId = PageHelper.GetIdInSpecialWay(Page.Request[ArticleIdKey]);
                if (CurrentArticleId != 0)
                {
                    BindControlsSafe(CurrentArticleId);

                    btnCreateTeaser.Enabled = true;
                }
                else
                {
                    btnCreateTeaser.Enabled = false;
                }
            }
        }

        private Article GetArticle(int articleId)
        {
            return articleId != 0 ? articleService.Repository.Read(articleId) : null;
        }

        private void BindControlsSafe(int articleId)
        {
            try
            {
                var article = GetArticle(articleId);
                var articleType = articleService.GetArticleType(article);

                ddlArticleType.SelectedValue = articleType.Id.ToString(CultureInfo.InvariantCulture);
                txtArticleHeader.Text = article.Header;
                txtArticleText.Text = article.TextBody;
                txtPrice.Text = NumberFormatter.GetFormat(article.Price);
            }
            catch (Exception ex)
            {
                labArticleStatus.Text = ex.Message;
            }
        }

        protected void BtnSaveArticleClick(object sender, EventArgs e)
        {
            try
            {
                UpdateArticleUnsafe(CurrentArticleId);

                btnCreateTeaser.Enabled = true;
            }
            catch (Exception)
            {
                labArticleStatus.Text = "Cтатья не сохранена";
                throw;
            }
        }

        private void UpdateArticleUnsafe(int articleId)
        {
            int articleTypeId;
            if (!int.TryParse(ddlArticleType.SelectedValue, out articleTypeId))
            {
                throw new PageException("Wrong id");
            }

            double price;
            if (double.TryParse(txtPrice.Text, out price))
            {
                var currentArticle = new Article
                {
                    Id = articleId,
                    ArticleType = (ArticleTypes)articleTypeId,
                    Header = txtArticleHeader.Text,
                    TextBody = txtArticleText.Text,
                    Price = price
                };
                articleService.Repository.Update(currentArticle);
                CurrentArticleId = currentArticle.Id;

                labArticleStatus.Text = articleId == 0 ? "Статья создана" : "Статья сохранена";
            }
            else
            {
                labArticleStatus.Text = "Введите число для цены";
            }
        }

        protected void BtnCreateTeaserClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentArticleId == 0)
                {
                    throw new PageException("Нельзя создать тизер у несуществующей статьи");
                }

                Page.Response.Redirect("~/EditorPages/Teasers/TeaserDetailsPage.aspx?articleId=" + CurrentArticleId);
            }
            catch (Exception ex)
            {
                labArticleStatus.Text = "Cтатья не сохранена. " + ex.Message;
            }
        }
    }
}