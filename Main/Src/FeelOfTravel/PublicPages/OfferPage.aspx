<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OfferPage.aspx.cs" Inherits="FeelOfTravel.PublicPages.OfferPage" %>
<%@ Register tagPrefix="FeelOfTravel" tagName="CommonArticleInformationControl" src="../Controls/CommonArticleInformationControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <style type="text/css">
  .b-article {
    
  }  
    
  .b-article__header {
    font-size: 16px;
    font-weight: bold;

    margin-bottom: 8px;
  }
  
  .b-article__image {
    width: 300px;
    float: left;
    margin-right: 10px;
  }
  
  .b-offer__price {
    color: gray;
  }
  
  .b-article p {
    text-align: justify;
  }
  
  .b-article__text {
  } 
  
  </style>

  <div class="b-article">
    <div class="b-article__header">
      <asp:Literal runat="server" ID="lblHeader"></asp:Literal>
    </div>
    <div class="b-offer__price">
      Цена: <asp:Label runat="server" ID="lblPrice"></asp:Label>
    </div>
    <div class="cf">
      <p>
        <asp:Image runat="server" CssClass="b-article__image" ID="imgOffer"/>
        <asp:Label runat="server" ID="lblText" CssClass="b-article__text"></asp:Label>
      </p>
    </div>
    
    <FeelOfTravel:CommonArticleInformationControl ID="offerInformation" runat="server"></FeelOfTravel:CommonArticleInformationControl>
  </div>
</asp:Content>
