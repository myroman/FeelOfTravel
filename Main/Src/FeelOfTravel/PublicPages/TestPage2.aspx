<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage2.aspx.cs" Inherits="FeelOfTravel.PublicPages.TestPage2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/tinyMce/tiny_mce.js" type="text/javascript"></script>
<script type="text/javascript">
  $(document).ready(function () {

    //    tinyMCE.init({
    //      // General options
    //      mode: "textareas",
    //      //      elements: "contentEditor",
    //      theme: "advanced",
    //      plugins: "autolink,lists,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template",

    //      // Theme options
    //      theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,fontselect,fontsizeselect",
    //      theme_advanced_buttons2: "bullist,numlist,|,blockquote,|,undo,redo,|,image,code,|,insertdate,inserttime",
    //      theme_advanced_toolbar_location: "top",
    //      theme_advanced_toolbar_align: "left",
    //      theme_advanced_statusbar_location: "bottom",
    //      theme_advanced_resizing: true,

    //      // Skin options
    //      skin: "o2k7",
    //      skin_variant: "silver",

    //      // Example content CSS (should be your site CSS)
    //      content_css: "css/example.css",

    //      // Drop lists for link/image/media/template dialogs
    //      template_external_list_url: "js/template_list.js",
    //      external_link_list_url: "js/link_list.js",
    //      external_image_list_url: "js/image_list.js",
    //      media_external_list_url: "js/media_list.js",

    //      // Replace values for the template plugin
    //      template_replace_values: {
    //        username: "Some User",
    //        staffid: "991234"
    //      }
    //    });

    tinyMCE.init({
      mode: "textareas",
      theme: "simple",
      editor_selector: "mceSimple"
    });

    tinyMCE.init({
      mode: "textareas",
      theme: "advanced",
      editor_selector: "mceAdvanced"
    });

    var ed1 = $('.mceSimple').html('Hello');
    ed1.setContent('HHHH');
    //$("#elm1").html('&lt;p&gt;This is the first paragraph.&lt;/p&gt;');
  });
  

</script>
</head>
<body>
  <form id="form1" runat="server">
    
        <textarea name="content1" id="ed1" class="mceSimple" style="width:100%">
        </textarea>
        <textarea name="content2" class="mceAdvanced" style="width:100%">
        </textarea>


   <input type="button" id="btnText" value="Set text" />
   <input type="button" id="btnMsg" value="Message" />
  </form>
</body>
</html>
