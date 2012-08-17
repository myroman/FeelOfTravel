<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OfferDetailsPage.aspx.cs" Inherits="FeelOfTravel.EditorPages.Offers.OfferDetailsPage" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <script src="<%= ResolveClientUrl("~/Scripts/Utils.js") %>"></script>
  <link href="<%= ResolveClientUrl("~/Styles/editor-management.css") %>" rel="stylesheet"/>
  <title> <%=Utils.MakeEditorHeader("Свойства статьи")%> </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Свойства статьи
  </h2>
  
  <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
  
  <asp:UpdatePanel runat="server">
    <ContentTemplate>

    <div class="entity-main-div">
      
      <label class="entity-label">Тип статьи:</label>
      <asp:DropDownList CssClass="entity-simple-text" runat="server" ID="ddlOfferType"/> <br class="entity-br"/>
      <label class="entity-label">Заголовок:</label>
      <asp:TextBox CssClass="entity-simple-text" runat="server" ID="txtHeader"/><br class="entity-br"/>
      <label class="entity-label">Текст статьи:</label>
      <asp:TextBox CssClass="entity-memo" runat="server" ID="txtText" TextMode="MultiLine"/><br class="entity-br"/>
      <label class="entity-label">Цена:</label>
      <asp:TextBox CssClass="entity-money-amount" runat="server" ID="txtPrice"></asp:TextBox><br class="entity-br"/>
         
      <ajaxToolkit:AsyncFileUpload runat="server" ID="afuImageUpload" 
        OnUploadedComplete="AfuImageUpload_OnUploadedComplete" Width="500px"
          UploaderStyle="Modern" UploadingBackColor="#CCFFFF" />
        
        <script type="text/javascript">
          function <%= GetUploadCompleteCallbackName() %>(sender, args) {
            linkImageFile('<%=imgOfferImage.ClientID %>', args.get_fileName());
          }
        </script>
        
        <asp:Image ID="imgOfferImage" runat="server" CssClass="editor-teaser-image" />

    </div>
    <br class="entity-br"/>

    <div>
      <asp:Button runat="server" ID="btnSaveArticle" Text="Сохранить" 
        onclick="BtnSaveOfferClick" CssClass="entity-buttonSubmit"/>
    </div>
    
      <asp:Label runat="server" ID="lblOfferStatus" CssClass="entity-label-status"></asp:Label>
    
    </ContentTemplate>
  </asp:UpdatePanel>
    
  
</asp:Content>
