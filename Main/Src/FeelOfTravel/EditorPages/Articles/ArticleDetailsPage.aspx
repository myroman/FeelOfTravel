<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticleDetailsPage.aspx.cs" Inherits="FeelOfTravel.EditorPages.Articles.ArticleDetailsPage" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <link href="<%= ResolveClientUrl("~/Styles/editor-management.css") %>" rel="stylesheet"/>
  <title> <%=Utils.MakeEditorHeader("Свойства статьи")%> </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Свойства статьи
  </h2>
  
  <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"> </ajaxToolkit:ToolkitScriptManager>
  <asp:UpdatePanel runat="server">
    <ContentTemplate>

    <div class="entity-main-div">
      <label class="entity-label">Тип статьи:</label>
      <asp:DropDownList CssClass="entity-simple-text" runat="server" ID="ddlArticleType"/> <br class="entity-br"/>
      <label class="entity-label">Заголовок:</label>
      <asp:TextBox CssClass="entity-simple-text" runat="server" ID="txtArticleHeader"/><br class="entity-br"/>
      <label class="entity-label">Текст статьи:</label>
      <asp:TextBox CssClass="entity-memo" runat="server" ID="txtArticleText" TextMode="MultiLine"/><br class="entity-br"/>
      <label class="entity-label">Цена:</label>
      <asp:TextBox CssClass="entity-money-amount" runat="server" ID="txtPrice"></asp:TextBox><br class="entity-br"/>
         
    </div>
    <br class="entity-br"/>

    <div>
      <asp:Button runat="server" ID="btnSaveArticle" Text="Сохранить" 
        onclick="BtnSaveArticleClick" CssClass="entity-buttonSubmit"/>
      <asp:Button runat="server" ID="btnCreateTeaser" Text="Cоздать тизер" 
        onclick="BtnCreateTeaserClick"/>
    </div>
    
      <asp:Label runat="server" ID="labArticleStatus" CssClass="entity-label-status"></asp:Label>
    
    </ContentTemplate>
  </asp:UpdatePanel>
    
  
</asp:Content>
