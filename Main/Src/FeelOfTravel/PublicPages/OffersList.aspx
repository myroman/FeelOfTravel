<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OffersList.aspx.cs" Inherits="FeelOfTravel.PublicPages.OffersList" %>
<%@ Register tagPrefix="FeelOfTravel" tagName="CommonArticleInformation" src="../Controls/CommonArticleInformationControl.ascx" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <title>
      <%=GetHeaderText()%>
  </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <h2>
    <%= OfferTypeName %>
  </h2>
  
<asp:Repeater ID="rptOffersList" runat="server" OnItemDataBound="OnOffersDataBound">
  <ItemTemplate>
    <asp:HyperLink id="lnkArticleLink" runat="server">
      <div class="public-teaser">
        <div class="public-teaser__left">
          <asp:Image ID="imgOffer" alt="Offer image" class="public-teaser-image" runat="server" />
          
          <div class="public-teaser-price">
            <label>Цена:</label>
            <asp:Label runat="server" ID="lblPrice"></asp:Label>
          </div>
        </div>
        
        <div class="public-teaser__right">
          <asp:Label id="lblHeader" runat="server" class="public-teaser-preamble"></asp:Label>
        </div>
        <br />
      </div>
    </asp:HyperLink>
    
    <FeelOfTravel:CommonArticleInformation runat="server" ID="offerInformation"/>
    <hr/>
  </ItemTemplate>
</asp:Repeater>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
