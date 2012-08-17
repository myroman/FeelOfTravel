<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonArticleInformationControl.ascx.cs" Inherits="FeelOfTravel.Controls.CommonArticleInformationControl" %>
<style>
  .b-article__common-info {
    border-top: dotted 1px #D1B683;
    border-bottom: dotted 1px #D1B683;

    color: #545454;

    padding: 10px 0;
    margin-top: 10px;

    font-size: 11px;
  }
</style>
<div class="b-article__common-info">
      Дата: <asp:Label ID="lblOfferDate" runat="server"></asp:Label>,
      Категория: <asp:PlaceHolder runat="server" ID="plhCategoryLinks"/>
      <%--<asp:HyperLink runat="server" ID="lnkCategory"></asp:HyperLink>--%>
</div>