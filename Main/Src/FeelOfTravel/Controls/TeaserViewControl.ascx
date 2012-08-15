<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeaserViewControl.ascx.cs" Inherits="FeelOfTravel.Controls.TeaserViewControl" %>

<asp:Repeater ID="rptTeaserView" runat="server" OnItemDataBound="OnTeasersDataBound">
  <ItemTemplate>
    <asp:HyperLink id="lnkArticleLink" runat="server">
      <div class="public-teaser">
        <div class="public-teaser__left">
          <asp:Image ID="imgTeaser" alt="Teaser image" class="public-teaser-image" runat="server" />
          
          <div class="public-teaser-price">
            <label>Цена:</label>
            <asp:Label runat="server" ID="lblPrice"></asp:Label>
          </div>
        </div>
        
        <div class="public-teaser__right">
          <asp:Label id="lblPreamble" runat="server" class="public-teaser-preamble"></asp:Label>
        </div>
        <br />
      </div>
    </asp:HyperLink>
    <hr/>
  </ItemTemplate>
</asp:Repeater>
