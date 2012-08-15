/* File Created: мая 30, 2012 */
EditorControl = function () {

  var init = function (params) {
    var that = this;

    var statusSelector = params.statusSelector;

    function initTinyMce(editorSelector) {
      tinyMCE.init({
        // General options
        mode: "textareas",
        theme: "advanced",
        plugins: "autolink,lists,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template",
        editor_selector: editorSelector,

        theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,fontselect,fontsizeselect",
        theme_advanced_buttons2: "bullist,numlist,|,blockquote,|,undo,redo,|,image,code,|,insertdate,inserttime",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: true,

        // Skin options
        skin: "o2k7",
        skin_variant: "silver",

        // Example word content CSS (should be your site CSS) this one removes paragraph margins
        content_css: "/Styles/word.css",

        // Replace values for the template plugin
        template_replace_values: {
          username: "Some User",
          staffid: "991234"
        }
      });
    }

    initTinyMce('editor-about-page__about');
    initTinyMce('editor-about-page__contacts');

    var setContent = function (about, contacts) {
      $('.editor-about-page__about').html(about);
      $('.editor-about-page__contacts').html(contacts);
    };

    var escapeQuotes = function (text) {
      var s = text.replace(/\"/g, '&quot;');

      return s;
    };

    var getContent = function () {

      var about = tinyMCE.get('aboutEditor').getContent({ format: 'raw' });
      var contacts = tinyMCE.get('contactsEditor').getContent({ format: 'raw' });
      var obj = {
        About: escapeQuotes(about),
        Contacts: escapeQuotes(contacts)
      };

      var jsonText = JSON.stringify(obj, null, 2);
      return jsonText;
    };

    $('.' + params.containerClass + ' input[type="button"]').click(function () {
      var data = getContent();
      saveContent(data);
    });

    var saveContent = function (content) {
      var query = 'TinyMceEditorHandler.axd' + "?" + $.param({ action: "save" });
      $.ajax({
        type: "POST",
        url: query,
        async: false,
        dataType: "json",
        data: {
          data: content
        },

        success: function (data) {
          console.log(data);
        },
        error: function (data) {
          var currentLabel = $('.' + statusSelector).removeClass('label-success').addClass('label-error');
          $(currentLabel).text(data.responseText);
        }
      });
    };

    that.refreshContent = function () {
      var query = 'TinyMceEditorHandler.axd' + "?" + $.param({ action: "get" });

      $.ajax({
        type: "GET",
        url: query,
        async: false,
        dataType: "json",
        data: {
        },

        success: function (data) {
          var parsed = $.parseJSON(data);
          setContent(parsed.About, parsed.Contacts);
        },
        error: function (data) {
          var currentLabel = $('.' + statusSelector).removeClass('label-success').addClass('label-error');
          $(currentLabel).text(data.responseText);
        }
      });
    };

    that.refreshContent();
  };

  return {
    Initialize: init
  };
};