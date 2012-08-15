using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic.Common;
using FeelOfTravel.Model.Utils;

namespace FeelOfTravel.Logic
{
    public class TeasersProvider : IEditorEntitiesProvider
    {
        private ITeaserService teaserService;

        public TeasersProvider(ITeaserService teaserService)
        {
            if (teaserService == null)
            {
                throw new ArgumentNullException("teaserService");
            }
            this.teaserService = teaserService;
        }

        public string GetItemText(object dataItem)
        {
            var teaser = dataItem as Teaser;
            if (teaser == null) return null;

            return teaser.Preamble;
        }

        public EntitiesTransferObject EntitiesTransferObject
        {
            get
            {
                var transferObj = new EntitiesTransferObject
                {
                    EntityDetailsUrl = "TeaserDetailsPage.aspx",
                    EntityUrlParam = "teaserId",
                    EntityDeleteUrl = "TeaserManagementPage.aspx",
                    JsonEntitiesList = GetJsonEntitiesList(),
                    MessageForDelete = MessageForDelete,
                    RefreshType = "teaser"
                };

                return transferObj;
            }
        }

        private string GetJsonEntitiesList()
        {
            string jsonArticles = Teasers.Select(teaser => new
            {
                teaser.Id,
                Description = teaser.Preamble
                    .SafeCrop(40)
                    .Replace('\n', ' ')
            }).ToArray().ToJSON();

            return jsonArticles;
        }

        private string MessageForDelete
        {
            get { return "Вы уверены, что хотите удалить тизер?"; }
        }

        private Teaser[] teasers;

        public Teaser[] Teasers
        {
            get { return teasers ?? (teasers = teaserService.GetTeasers()); }
        }
    }
}