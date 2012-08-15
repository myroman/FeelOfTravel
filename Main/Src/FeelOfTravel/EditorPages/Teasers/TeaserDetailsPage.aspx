<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TeaserDetailsPage.aspx.cs"
  Inherits="FeelOfTravel.EditorPages.Teasers.TeaserDetailsPage" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <script src="<%= ResolveClientUrl("~/Scripts/Utils.js") %>"></script>
  <link href="<%= ResolveClientUrl("~/Styles/editor-management.css") %>" rel="stylesheet"/>
  <link href="<%= ResolveClientUrl("~/Styles/editor-teaser-properties.css") %>" rel="stylesheet"/>
  <title> <%=Utils.MakeEditorHeader("Свойства тизера")%> </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Свойства тизера
  </h2>

  <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
  </ajaxToolkit:ToolkitScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      
      <div class="entity-main-div">
      
        <ajaxToolkit:AsyncFileUpload runat="server" ID="afuImageUpload" 
        OnUploadedComplete="AfuImageUpload_OnUploadedComplete" Width="500px"
          UploaderStyle="Modern" UploadingBackColor="#CCFFFF" />
        
        <script type="text/javascript">
          function <%= GetUploadCompleteCallbackName() %>(sender, args) {
            linkImageFile('<%=imgBanner.ClientID %>', args.get_fileName());
          }
        </script>
        
        <asp:Image ID="imgBanner" runat="server" CssClass="editor-teaser-image" />

        <br class="entity-br" />
        <label class="entity-label">Изображение</label>
        <asp:TextBox runat="server" ID="txtImageFileName" CssClass="entity-simple-text" ReadOnly="True" />
        <br class="entity-br" />
        
        <label class="entity-label">Заголовок</label>
        <asp:TextBox runat="server" ID="txtTeaserPreamble" CssClass="entity-simple-text" />
        <br class="entity-br" />

        <label class="entity-label">Статья</label>
        <asp:TextBox runat="server" ID="txtArticleLink" CssClass="entity-simple-text" ReadOnly="True" />
        <br class="entity-br" />
        
      </div>   
      <br class="entity-br" />

      <div>
        <asp:Button runat="server" ID="btnSaveTeaser" Text="Сохранить" OnClick="BtnSaveTeaserClick" />
      </div>
      
      <asp:Label CssClass="entity-label-status" runat="server" ID="labTeaserStatus"></asp:Label>
        <br class="entity-br" />
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
