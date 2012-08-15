<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TinyMceEditorControl.ascx.cs" Inherits="FeelOfTravel.Controls.TinyMceEditorControl" %>
<link type="text/css" href="../Styles/editor/editor__about-page.css" rel="stylesheet"/>
<script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="/Scripts/tinyMce/tiny_mce.js" type="text/javascript"></script>
<%--<script src="../Scripts/json2.js" type="text/javascript"></script>--%>
<script src="/Scripts/EditorControl.js" type="text/javascript"></script>

<div class="<%# ContainerCssClass %>">
  <div class=""></div>
   <h2>
    Редактор "О нас"
  </h2>
    <textarea class="editor-about-page__about" id="aboutEditor" style="width:100%; height:200px;">      
    </textarea>
     <h2>
    Контакты
  </h2>
    <textarea class="editor-about-page__contacts" id="contactsEditor" style="width:100%; height:200px;">      
    </textarea>
    
    <input type="button" value="Сохранить"/>
    <div class="entity-label-status">
    </div>
</div>

<script>
  $(document).ready(function () {
    var editControl = EditorControl();
    editControl.Initialize({
      textAreaClass: "<%= TextAreaCssClass%>",
      containerClass: "<%= ContainerCssClass%>",
      bizObjectType: "<%= BizObjTypeName %>",
      statusSelector: "entity-label-status"
    });

    editControl.refreshContent();
  });
</script>