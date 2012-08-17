using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Business.Services.CategoryPresenter;
using FeelOfTravel.Logic;

namespace FeelOfTravel.Controls
{
    public partial class CommonArticleInformationControl : UserControl
    {
        private ICategoryRepository categoryRepository;

        private ICategoryPresenter categoryPresenter;

        public void Bind(CoreArticleData articleData)
        {
            categoryRepository = CompositionRootHelper.GetCompositionRoot(Context).CategoryRepository;
            categoryPresenter = CompositionRootHelper.GetCompositionRoot(Context).CategoryPresenter;

            if (articleData != null)
            {
                lblOfferDate.Text = articleData.PublishDate.ToLongDateString();

                var categories = categoryPresenter.GetCategories(articleData);
                foreach (var categoryData in categories)
                {
                    plhCategoryLinks.Controls.Add(CreateLink(categoryData));
                    if (categoryData != categories.Last())
                    {
                        plhCategoryLinks.Controls.Add(new Literal { Text = ", " });
                    }
                }
            }
        }

        private HyperLink CreateLink(CategoryData categoryData)
        {
            return new HyperLink
            {
                Text = categoryData.Name,
                NavigateUrl = categoryData.Link
            };
        }
    }
}