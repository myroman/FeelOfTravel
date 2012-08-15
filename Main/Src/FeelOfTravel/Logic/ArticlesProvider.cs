using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic.Common;
using FeelOfTravel.Model.Utils;

namespace FeelOfTravel.Logic
{
    public class ArticlesProvider : IEditorEntitiesProvider
    {
        private IArticleService articleService;

        public ArticlesProvider(IArticleService articleService)
        {
            if (articleService == null)
            {
                throw new ArgumentNullException("articleService");
            }
            this.articleService = articleService;
        }

        public string GetItemText(object dataItem)
        {
            var article = dataItem as Article;
            if (article == null) return null;

            return article.Header;
        }

        private Article[] articles;

        public Article[] Articles
        {
            get { return articles ?? (articles = articleService.GetArticles()); }
        }

        public EntitiesTransferObject EntitiesTransferObject
        {
            get
            {
                var transferObj = new EntitiesTransferObject
                {
                    EntityDetailsUrl = "ArticleDetailsPage.aspx",
                    EntityUrlParam = "articleId",
                    EntityDeleteUrl = "ArticleManagementPage.aspx",
                    JsonEntitiesList = GetJsonEntitiesList(),
                    MessageForDelete = MessageForDelete,
                    RefreshType = "article"
                };

                return transferObj;
            }
        }

        private string GetJsonEntitiesList()
        {
            string jsonArticles = Articles.Select(art => new
            {
                art.Id,
                Description = art.TextBody
                    .SafeCrop(40)
                    .Replace('\n', ' ')
            }).ToArray().ToJSON();

            return jsonArticles;
        }

        private string MessageForDelete
        {
            get { return "Вы уверены, что хотите удалить статью?"; }
        }
    }
}