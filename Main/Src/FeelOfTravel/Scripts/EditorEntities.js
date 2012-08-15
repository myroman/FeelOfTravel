/* File Created: мая 22, 2012 */
EditorEntities = function () {

  var init = function (params) {
    var entObj = params.entObj;
    var entities = $.parseJSON(entObj.JsonEntitiesList);
    var editActionUrl = entObj.EntityDetailsUrl;
    var queryParam = entObj.EntityUrlParam;
    var refreshType = entObj.RefreshType;

    var deleteActionUrl = entObj.EntityDeleteUrl;
    var confirmMsgToDelete = entObj.MessageForDelete;

    var editControlSelector = '.entity-edit';
    var deleteControlSelector = '.entity-delete';

    var bindEvents = function () {

      $(editControlSelector).click(function () {
        var currentIndex = $(editControlSelector).index(this);

        if (currentIndex < entities.length) {
          var entityPage = editActionUrl + '?' + queryParam + '=' + entities[currentIndex].Id;

          window.location = entityPage;
        }
      });


      $(deleteControlSelector).click(function () {
        var currentIndex = $(deleteControlSelector).index(this);
        if ((currentIndex < 0)||(currentIndex >= entities.length)) {
          return;
        }

        if (confirmDelete(confirmMsgToDelete)) {
          deleteEntity(currentIndex);
          refreshEntities();
        }

      });

      var deleteEntity = function (currentIndex) {
        $.ajax({
          type: 'POST',
          url: deleteActionUrl,
          async: false,
          dataType: 'json',
          data: {
            idToDelete: entities[currentIndex].Id
          },

          success: function () {
            var currentLabel = $('.label-entity-in-list').get(currentIndex);
            $(currentLabel).css('color', 'gray');
            $(currentLabel).text('Удалено');

            $('.entity-label-status').removeClass('label-error').addClass('label-success');
          },
          error: function (data) {
            var currentLabel = $('.entity-label-status').removeClass('label-success').addClass('label-error');
            $(currentLabel).text(data.responseText);
          }
        });
      };

      $(function () {
        $("span.label-entity-in-list").tooltip({
          bodyHandler: function () {
            var index = $("span.label-entity-in-list").index(this);

            if (index < entities.length)
              return entities[index].Description;
            return '';
          },
          showURL: false
        });
      });

      $('.entity-list-refresh > input').click(function () {
        refreshEntities();
      });

      var refreshEntities = function () {
        var query = 'RefreshHandler.axd' + "?" + $.param({ type: refreshType });
        $.ajax({
          type: 'POST',
          url: query,
          data: {},

          success: function (data) {
            $('.entity-list').html(data);
            
            if (editorEntitiesControl.refreshData) {
              entities = editorEntitiesControl.refreshData();
            }
          }
        });
      };

    };
    bindEvents();
  };

  return {
    Initialize: init
  };
};

var editorEntitiesControl = new EditorEntities();